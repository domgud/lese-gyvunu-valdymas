using Microsoft.AspNetCore.Mvc;
using AnimalShelterAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace AnimalShelterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : ApiControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;

        public UsersController(
            IConfiguration config,
            UserManager<User> userManager,
            SignInManager<User> signInManager
            )
        {
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            var user = new User { UserName = userDTO.Email, Email = userDTO.Email };
            var res = await _userManager.CreateAsync(user, userDTO.Password);
            if (!res.Succeeded)
                return BadRequest(res.Errors.First().Description);

            return Created("", new
            {
                token = GenerateJWTToken(new UserDTO()
                {
                    Email = userDTO.Email
                })
            });

        }

        [HttpPost]
        public async Task<IActionResult> Login(UserDTO userDTO)
        {
            var user = await _userManager.FindByEmailAsync(userDTO.Email);
            if (user == null)
                return BadRequest("User does not exist");

            var res = await _signInManager.PasswordSignInAsync(user, userDTO.Password, false, false);
            if (!res.Succeeded)
                return BadRequest("Invalid password");

            return Ok(new
            {
                token = GenerateJWTToken(new UserDTO()
                {
                    Email = userDTO.Email
                })
            });
        }

        string GenerateJWTToken(UserDTO userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTSecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
            var token = new JwtSecurityToken(
            issuer: _config["JWTIssuer"],
            audience: _config["JWTAudience"],
            claims: claims,
            expires: DateTime.Now.AddDays(30),
            signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}