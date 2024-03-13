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
    }
}
