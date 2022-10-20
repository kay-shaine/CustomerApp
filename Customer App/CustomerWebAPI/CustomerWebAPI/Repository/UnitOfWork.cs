using CustomerWebAPI.RepositoryInterface;
using CustomerWebAPI.Data;
using CustomerWebAPI.Entities;
using CustomerWebAPI.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace CustomerWebAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly CustomerDbContext _context;
        private ICustomerRepository _customerRepository;

        public UnitOfWork(CustomerDbContext context, ICustomerRepository customerRepository)
        {
            _context = context;
            _customerRepository = customerRepository;   
        }


        
        public ICustomerRepository CustomerRepository => _customerRepository ??= new CustomerRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
