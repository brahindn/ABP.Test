using WebsiteParsing.Application.Services.Contracts.Services;
using WebsiteParsing.DataAccess.Repositories.Contracts;
using WebsiteParsing.Domain.Entities;

namespace WebsiteParsing.Application.Services.Implementation.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IRepositoryManager _repositoryManager;

        public EquipmentService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task CreateEquipmentAsync(string equipmentName, string engine, string body, string grade, string transmission, string gearShiftType, string cab, string transmissionModel, string loadingCapacity)
        {
            if(string.IsNullOrEmpty(equipmentName))
            {
                throw new ArgumentException("EquipmentName cannot be null or empty");
            }

            var equipment = new Equipment
            {
                EquipmentName = equipmentName,
                Engine = engine,
                Body = body,
                Grade = grade,
                Transmission = transmission,
                GearShiftType = gearShiftType,
                Cab = cab,
                TransmissionModel = transmissionModel,
                LoadingCapacity = loadingCapacity
            };

            _repositoryManager.Equipment.Create(equipment);
            await _repositoryManager.SaveAsync();
        }
    }
}
