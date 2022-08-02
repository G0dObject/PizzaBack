using AutoMapper;
using Pizza.Application.Common.Mapping.Entity;
using Pizza.Domain.Users;
using MD5Hash;

namespace Pizza.Application.Common.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            _ = CreateMap<CreateUser, User>().ForMember(f => f.PasswordHash, c => c.MapFrom(c => c.Password.GetMD5()));
        }
    }
}
