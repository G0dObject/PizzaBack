using AutoMapper;
using Pizza.Application.Common.Entity.Product;
using Pizza.Application.Common.Entity.User;
using Pizza.Domain.Entity;
using Pizza.Domain.Users;

namespace Pizza.Application.Common.Mapping.Profiles
{
	public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			_ = CreateMap<CreateUser, User>().ForMember(f => f.PasswordHash, c => c.MapFrom(c => c.Password));

			_ = CreateMap<GetProductMenu, Product>();
			_ = CreateMap<Product, GetProductMenu>().ForPath(f =>f.Size, c=>c.MapFrom(c=>c.Size!.SizeName));

			_ = CreateMap<CreateProduct, Product>().ForMember(f => f.Type, c => c.MapFrom(c => new Domain.Entity.Type() { TypeName = c.Type }))
				.ForMember(f => f.Size, c => c.MapFrom(c => new Size() { SizeName = c.Size![0] }));
		}
	}
}
