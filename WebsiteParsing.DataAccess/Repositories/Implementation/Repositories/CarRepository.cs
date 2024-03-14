using Microsoft.EntityFrameworkCore;
using WebsiteParsing.DataAccess.Repositories.Contracts.Repositories;
using WebsiteParsing.Domain.Entities;

namespace WebsiteParsing.DataAccess.Repositories.Implementation.Repositories
{
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public async Task<Car> GetCarAsync(Guid carId)
        {
            return await FindCondition(c => c.Id == carId).SingleOrDefaultAsync();
        }

        public async Task<Car> GetCarByCodeModelAsync(int carCodeModel)
        {
            return await FindCondition(c => c.ModelCode == carCodeModel).SingleOrDefaultAsync();
        }
    }
}
