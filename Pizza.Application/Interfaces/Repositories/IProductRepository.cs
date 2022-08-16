using Pizza.Application.Common.Entity.Product;

namespace Pizza.Application.Interfaces.Repositories
{
	public interface IProductRepository
	{
		public Task<ICollection<GetProductMenu>> GetMenu();
		public Task RemoveAll();
	}
}
