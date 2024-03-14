using System.Linq.Expressions;

namespace WebsiteParsing.DataAccess.Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        void Create(T entity);
        IQueryable<T> FindCondition(Expression<Func<T, bool>> expression);
    }
}
