using AutoMapper;
using CustomerWebAPI.Dto;
using CustomerWebAPI.Entities;
using CustomerWebAPI.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebAPI.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IList<Customer>> GetPagedCustomers(Pagination pagination)
        {
            return await _unitOfWork.CustomerRepository.GetAllCustomers(pagination.PageNumber, pagination.PageSize);
        }

        public async Task UpdateCustomer(Customer customer)
        { 
            _unitOfWork.CustomerRepository.Update(customer);

            await _unitOfWork.Save();
        }

        public async Task DeleteCustomer(int id)
        {
            await _unitOfWork.CustomerRepository.Delete(id);
            await _unitOfWork.Save();
        }

        public async Task Insert(Customer customer)
        {
            await _unitOfWork.CustomerRepository.Insert(customer);
            await _unitOfWork.Save();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            
            return await _unitOfWork.CustomerRepository.GetCustomer(id);
        }
    }
}
