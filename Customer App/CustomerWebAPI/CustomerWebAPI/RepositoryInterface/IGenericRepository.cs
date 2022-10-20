using System.Linq.Expressions;

namespace CustomerWebAPI.RepositoryInterface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAll(
            Expression<Func<T, bool>> expression = null,
            List<string> includes = null);

        Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null);
        Task Insert(T entity);
        Task InsertRange(IEnumerable<T> entities);
        Task Delete(int id);
        void DeleteRange(IEnumerable<T> entities);
        void Update(T entity);
    }
}
