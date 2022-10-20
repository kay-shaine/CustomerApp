using CustomerWebAPI.Data;
using CustomerWebAPI.Entities;
using CustomerWebAPI.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace CustomerWebAPI.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly CustomerDbContext _context;

        public CustomerRepository(CustomerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IList<Customer>> GetAllCustomers(int pageNumber, int pageSize)
        {
            var customers = await GetAll();
            var orderCustomers = customers.OrderBy(x => x.Id);

            return PageList<Customer>.ToPageList(orderCustomers, pageNumber, pageSize);
        }

        

        public Task<Customer> GetCustomer(int id)
        {
            return _context.Customers.Where(e => e.Id == id).FirstOrDefaultAsync();
        }
    } 
}
