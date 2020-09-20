using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelterAPI.Models
{
    public class ApiContext : IdentityDbContext<User>
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
