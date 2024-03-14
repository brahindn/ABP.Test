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

        public async Task CreateEquipmentAsync(int codeModel, string equipmentName, string engine, string body, string grade, string transmission, string gearShiftType, string cab, string transmissionModel, string loadingCapacity)
        {
            var existCar = await _repositoryManager.Car.GetCarByCodeModelAsync(codeModel);

            if (existCar == null || string.IsNullOrEmpty(equipmentName))
            {
                throw new ArgumentException("CodModel and EquipmentName cannot be null or empty");
            }

            var equipment = new Equipment
            {
                CarId = existCar.Id,
                CodeModel = codeModel,
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
