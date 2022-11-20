using AutoMapper;
using Domain;
using Domain.Dtos;

namespace TestProject.WebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UsersDto>();
            CreateMap<Account, AccountsDto>();
        }
    }
}
