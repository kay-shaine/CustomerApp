using CustomerWebAPI.Entities;

namespace CustomerWebAPI.RepositoryInterface
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<IList<Customer>> GetAllCustomers( int pageNumber, int pageSize);
        Task<Customer> GetCustomer( int id);
    }
}
