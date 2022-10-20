using CustomerWebAPI.Dto;
using CustomerWebAPI.Entities;

namespace CustomerWebAPI.Service
{
    public interface ICustomerService
    {
        Task<IList<Customer>> GetPagedCustomers(Pagination pagination); 
        Task<Customer> GetCustomer(int id);
        Task UpdateCustomer(Customer customer);

        Task DeleteCustomer(int id);

        Task Insert(Customer customer);

    }
}
