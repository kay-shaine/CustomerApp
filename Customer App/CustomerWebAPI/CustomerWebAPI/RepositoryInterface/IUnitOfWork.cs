using CustomerWebAPI.Entities;

namespace CustomerWebAPI.RepositoryInterface
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
        Task Save();
    }
}
