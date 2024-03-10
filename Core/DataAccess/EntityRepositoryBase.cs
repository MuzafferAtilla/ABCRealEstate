using System;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using Core.Entity;
using System.Linq.Expressions;

namespace Core.DataAccess
{
	public class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
                where TEntity : class, IAbcEntity, new()
                where TContext : DbContext
    {
        public TContext _context;
        public DbSet<TEntity> _entity;


        public EntityRepositoryBase(TContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            await _entity.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            _entity.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> GetById(Expression<Func<TEntity, bool>> filter)
        {
            return await _entity.Where(filter).FirstOrDefaultAsync();
        }

        public async Task<ICollection<TEntity>> GetList(Expression<Func<TEntity, bool>>? filter = null)
        {
            return filter == null ? await _entity.ToListAsync() : await _entity.Where(filter).ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _entity.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

