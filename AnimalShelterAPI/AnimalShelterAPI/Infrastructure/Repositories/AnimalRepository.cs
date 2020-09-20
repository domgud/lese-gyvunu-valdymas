using Microsoft.EntityFrameworkCore;
using System.Linq;
using AnimalShelterAPI.Models;

namespace AnimalShelterAPI.Infrastructure.Repositories
{
    public class AnimalRepository : RepositoryBase<Animal>
    {
        protected override DbSet<Animal> ItemSet { get; }

        public AnimalRepository(ApiContext context) : base(context)
        {
            ItemSet = context.Animals;
        }

        protected override IQueryable<Animal> IncludeDependencies(IQueryable<Animal> queryable)
        {
            return queryable.Include(x => x.Status);
        }
    }
}
