using WebsiteParsing.DataAccess.Repositories.Contracts.Repositories;

namespace WebsiteParsing.DataAccess.Repositories.Contracts
{
    public interface IRepositoryManager
    {
        ICarRepository Car { get; }
        IEquipmentRepository Equipment { get; }
        Task SaveAsync();
    }
}
