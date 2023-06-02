using AutoMapper;
using Pizza.Application.Common.Entity.Order;
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


			//_ = CreateMap<string, Type>().ForMember(f => f.TypeName, f => f.MapFrom(f => f)).ReverseMap();
			CreateMap<int, int>();


			CreateMap<int, Product>().ForMember(f => f.Id, f => f.MapFrom(f => f)).ReverseMap();

			CreateMap<Order, CreateOrder>().ForMember(f => f.Amount, f => f.MapFrom(f => f.Amount)).ForMember(f => f.ProductsId, f => f.MapFrom(f => f.Products.Select(f => f))).ReverseMap();

			_ = CreateMap<int, Size>().ForMember(f => f.SizeName, f => f.MapFrom(f => f)).ReverseMap();

			_ = CreateMap<GetProductMenu, Product>().ForMember(f => f.Id, f => f.MapFrom(f => f.Id));
			_ = CreateMap<Product, GetProductMenu>().ForMember(f => f.Id, f => f.MapFrom(f => f.Id));

			//.ForMember(f => f.Sizes, c => c.MapFrom(f => f.Sizes!.Select(f => new Size() { SizeName = f })))
			//	.ForMember(f => f.Types, c => c.MapFrom(f => f.Types!.Select(f => new Type() { TypeName = f }))).ReverseMap();

			_ = CreateMap<CreateProduct, Product>()
			.ForMember(f => f.Sizes, c => c.MapFrom(f => f.Sizes!.Select(f => new Size() { SizeName = f })))
				.ForMember(f => f.Types, c => c.MapFrom(f => f.Types!.Select(f => new Type() { TypeName = f })));
		}
	}

}
