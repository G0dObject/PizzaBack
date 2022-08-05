using Pizza.Application.Common.Mapping.Entity.Item;
using System.Collections.Generic;

namespace Pizza.Application.Interfaces.Repositories
{
    public interface IItemRepository
    {
        public Task<ICollection<GetItemMenu>> GetMenu();
    }
}
