using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using CustomerWebAPI.Data;
using CustomerWebAPI.RepositoryInterface;
using CustomerWebAPI.Entities;

namespace CustomerWebAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        private readonly CustomerDbContext _context;
        private readonly DbSet<T> _db;
        public GenericRepository(CustomerDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }


        public Task<IQueryable<T>> GetAll(Expression<Func<T, bool>> expression = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

           
            return Task.FromResult(query.AsNoTracking());
        }

        

        public async Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

       

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        //Task IGenericRepository<T>.GetCustomer(int id)
        //{
        //    return _context.Customers.Where(e => e.Id == id).FirstOrDefaultAsync();
        //}
    }
}
