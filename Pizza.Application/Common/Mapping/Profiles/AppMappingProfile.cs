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


			//_ = CreateMap<string, Type>().ForMember(f => f.TypeName, f => f.MapFrom(f => f)).ReverseMap();
			CreateMap<int, int>();
			_ = CreateMap<int, Size>().ForMember(f => f.SizeName, f => f.MapFrom(f => f)).ReverseMap();

			_ = CreateMap<GetProductMenu, Product>().ForMember(f => f.Id, f => f.MapFrom(f => f.Id)).ReverseMap();

			//.ForMember(f => f.Sizes, c => c.MapFrom(f => f.Sizes!.Select(f => new Size() { SizeName = f })))
			//	.ForMember(f => f.Types, c => c.MapFrom(f => f.Types!.Select(f => new Type() { TypeName = f }))).ReverseMap();

			_ = CreateMap<CreateProduct, Product>()
			.ForMember(f => f.Sizes, c => c.MapFrom(f => f.Sizes!.Select(f => new Size() { SizeName = f })))
				.ForMember(f => f.Types, c => c.MapFrom(f => f.Types!.Select(f => new Type() { TypeName = f })));
		}
	}

}
