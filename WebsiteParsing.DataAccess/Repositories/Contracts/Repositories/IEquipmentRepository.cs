using WebsiteParsing.Domain.Entities;

namespace WebsiteParsing.DataAccess.Repositories.Contracts.Repositories
{
    public interface IEquipmentRepository
    {
        void Create(Equipment equipment);
    }
}
