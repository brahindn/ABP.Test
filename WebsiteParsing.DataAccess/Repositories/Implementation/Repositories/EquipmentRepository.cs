using WebsiteParsing.DataAccess.Repositories.Contracts.Repositories;
using WebsiteParsing.Domain.Entities;

namespace WebsiteParsing.DataAccess.Repositories.Implementation.Repositories
{
    public class EquipmentRepository : RepositoryBase<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
