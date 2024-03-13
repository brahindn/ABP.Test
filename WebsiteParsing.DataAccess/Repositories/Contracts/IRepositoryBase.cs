namespace WebsiteParsing.DataAccess.Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        void Create(T entity);
    }
}
