using AutoMapper;
using CustomerWebAPI.Dto;
using CustomerWebAPI.Entities;

namespace CustomerWebAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CustomerDto>();
        }
       
    }
}
