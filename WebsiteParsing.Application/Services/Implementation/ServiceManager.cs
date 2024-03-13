using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteParsing.Application.Services.Contracts;
using WebsiteParsing.Application.Services.Contracts.Services;
using WebsiteParsing.Application.Services.Implementation.Services;
using WebsiteParsing.DataAccess.Repositories.Contracts;

namespace WebsiteParsing.Application.Services.Implementation
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICarService> _carService;
        private readonly Lazy<IEquipmentService> _equipmentService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _carService = new Lazy<ICarService>(() => new CarService(repositoryManager));
            _equipmentService = new Lazy<IEquipmentService>(() => new EquipmentService(repositoryManager));
        }

        public ICarService CarService => _carService.Value;
        public IEquipmentService EquipmentService => _equipmentService.Value;
    }
}
