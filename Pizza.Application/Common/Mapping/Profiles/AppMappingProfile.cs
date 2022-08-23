using AutoMapper;
using Pizza.Application.Common.Entity.Product;
using Pizza.Application.Common.Entity.User;
using Pizza.Domain.Entity;
using Pizza.Domain.Users;
using System.Linq.Expressions;

namespace Pizza.Application.Common.Mapping.Profiles
{
	public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			var g = new List<Size>();

			Expression<Func<CreateProduct, Product>> storeConverter = p => new Product
			{
				 
				
			};


			_ = CreateMap<CreateUser, User>().ForMember(f => f.PasswordHash, c => c.MapFrom(c => c.Password));

			_ = CreateMap<GetProductMenu, Product>();
			_ = CreateMap<Product, GetProductMenu>().ForPath(f => f.Size, c => c.MapFrom(f => f.Sizes.Select(f=>f.SizeName)));

			_ = CreateMap<CreateProduct, Product>()
				.ForMember(f => f.Type, c => c.MapFrom(c => new Domain.Entity.Type() { TypeName = c.Type }))
				.ForMember(f => f.Sizes, c => c.MapFrom(f => f.Size!.Select(f=>new Size() { SizeName = f})));
		}
	}

}
