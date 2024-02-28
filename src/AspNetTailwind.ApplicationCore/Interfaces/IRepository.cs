using System.Linq.Expressions;
using AspNetTailwind.ApplicationCore.Models;

namespace AspNetTailwind.ApplicationCore.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<TEntity> Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);

        Task Update(TEntity entity);
        Task UpdateRange(IEnumerable<TEntity> entities);

        Task Remove(TEntity entity);
        Task RemoveRange(IEnumerable<TEntity> entities);

        Task<TEntity?> Get(int id);
        Task<TEntity?> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetAll();
    }
}
