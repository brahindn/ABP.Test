using WebsiteParsing.Domain.Entities;

namespace WebsiteParsing.DataAccess.Repositories.Contracts.Repositories
{
    public interface ICarRepository
    {
        void Create(Car car);
        Task<Car> GetCarAsync(Guid carId);
        Task<Car> GetCarByCodeModelAsync(int carCodeModel);
    }
}
