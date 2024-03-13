using WebsiteParsing.Application.Services.Contracts.Services;
using WebsiteParsing.DataAccess.Repositories.Contracts;
using WebsiteParsing.Domain.Entities;

namespace WebsiteParsing.Application.Services.Implementation.Services
{
    public class CarService : ICarService
    {
        private readonly IRepositoryManager _repositoriesManager;

        public CarService(IRepositoryManager repositoriesManager)
        {
            _repositoriesManager = repositoriesManager;
        }

        public async Task CreateCarAsync(string modelName, int modelCode, DateTime dateRange)
        {
            if (string.IsNullOrEmpty(modelName) || modelCode == null)
            {
                return;
            }

            var car = new Car
            {
                ModelName = modelName,
                ModelCode = modelCode,
                DateRange = dateRange
            };

            _repositoriesManager.Car.Create(car);
            await _repositoriesManager.SaveAsync();
        }
    }
}
