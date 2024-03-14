namespace WebsiteParsing.Application.Services.Contracts.Services
{
    public interface IEquipmentService
    {
        Task CreateEquipmentAsync(int codeModel, string equipmentName, string engine, string body, string grade, string transmission, string gearShiftType, string cab, string transmissionModel, string loadingCapacity);
    }
}
