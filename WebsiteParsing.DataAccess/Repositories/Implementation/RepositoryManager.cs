using WebsiteParsing.DataAccess.Repositories.Contracts;
using WebsiteParsing.DataAccess.Repositories.Contracts.Repositories;
using WebsiteParsing.DataAccess.Repositories.Implementation.Repositories;

namespace WebsiteParsing.DataAccess.Repositories.Implementation
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;

        private readonly Lazy<ICarRepository> _carRepository;
        private readonly Lazy<IEquipmentRepository> _equipmentRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

            _carRepository = new Lazy<ICarRepository>(() => new CarRepository(repositoryContext));
            _equipmentRepository = new Lazy<IEquipmentRepository>(() => new EquipmentRepository(repositoryContext));
        }

        public ICarRepository Car => _carRepository.Value;
        public IEquipmentRepository Equipment => _equipmentRepository.Value;
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
