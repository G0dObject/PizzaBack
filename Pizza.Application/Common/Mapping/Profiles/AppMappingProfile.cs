using AutoMapper;
using MD5Hash;
using Pizza.Application.Common.Mapping.Entity.Product;
using Pizza.Application.Common.Mapping.Entity.User;
using Pizza.Domain.Entity;
using Pizza.Domain.Users;

namespace Pizza.Application.Common.Mapping.Profiles
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            _ = CreateMap<CreateUser, User>().ForMember(f => f.PasswordHash, c => c.MapFrom(c => c.Password.GetMD5()));
            _ = CreateMap<GetProductMenu, Product>().ReverseMap();
            _ = CreateMap<CreateProduct, Product>().
                ForMember(f => f.Type, c => c.MapFrom(c => new Domain.Entity.Type() { TypeName = c.Type }))
                .ForMember(f => f.Size, c => c.MapFrom(c => new Size() { SizeName = c.Size![0] }));


        }
    }
}
