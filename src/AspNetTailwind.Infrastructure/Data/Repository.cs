using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AspNetTailwind.ApplicationCore.Models;
using AspNetTailwind.ApplicationCore.Interfaces;

namespace AspNetTailwind.Infrastructure.Data
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity?> FirstOrDefault(Expression<Func<TEntity, bool>> predicate) =>
            await _dbSet.FirstOrDefaultAsync(predicate);

        public async Task<TEntity?> Get(int id) => await _dbSet.FindAsync(id);

        public async Task<List<TEntity>> GetAll() => await _dbSet.ToListAsync();

        public async Task Remove(TEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
