using AutoMapper;
using Pizza.Application.Common.Mapping.Entity;
using Pizza.Domain.Users;

namespace Pizza.Application.Common.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<CreateUser, User>();                            
        }
    }
}
