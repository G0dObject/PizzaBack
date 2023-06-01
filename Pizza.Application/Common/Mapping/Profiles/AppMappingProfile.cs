using AutoMapper;
using Pizza.Application.Common.Entity.Product;
using Pizza.Application.Common.Entity.User;
using Pizza.Domain.Entity;
using Pizza.Domain.Users;
using System.Linq.Expressions;
using Type = Pizza.Domain.Entity.Type;

namespace Pizza.Application.Common.Mapping.Profiles
{
	public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			_ = CreateMap<CreateUser, User>().ForMember(f => f.PasswordHash, c => c.MapFrom(c => c.Password));

			_ = CreateMap<GetProductMenu, Product>();
			_ = CreateMap<Product, GetProductMenu>().ForPath(f => f.Size, c => c.MapFrom(f => f.Sizes.Select(f => f.SizeName)));
			_ = CreateMap<CreateProduct, Product>()
			.ForMember(f => f.Sizes, c => c.MapFrom(f => f.Sizes!.Select(f => new Size() { SizeName = f })))
				.ForMember(f => f.Types, c => c.MapFrom(f => f.Types!.Select(f => new Type() { TypeName = f })));
		}
	}

}
