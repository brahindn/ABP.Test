using WebsiteParsing.Application.Services.Contracts.Services;

namespace WebsiteParsing.Application.Services.Contracts
{
    public interface IServiceManager
    {
        ICarService CarService { get; }
        IEquipmentService EquipmentService { get; }
    }
}
