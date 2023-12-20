using APIproject.Entities.Base;
using System.Linq.Expressions;

namespace APIproject.Repositories.Interfaces
{
        public interface IRepository<T> where T : BaseEntity
        {

            Task<IQueryable<T>> GetAll(Expression<Func<T, bool>>? expression = null, params string[] includes);
            Task<T> GetByIdAsync(int id);
            Task Create(T entity);
            void Update(T entity);
            void Delete(T entity);
            Task SaveChangesAsync();
        }
    
}
