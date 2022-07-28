using Pizza.Application.Interfaces;

namespace Pizza.Application.Common.Repositories
{
    public abstract class GenericRepository<T>
    {
        public GenericRepository(IContext context)
        {

        }
        public abstract Task<T> GetById(int id);        
        public abstract Task Add(T entity);
        public abstract Task Remove(T entity);

        public abstract Task<IEnumerable<T>> GetAll();

    }
}
