using System.Linq.Expressions;
using _02.kanban.Application.Interfaces.Repository;
using _03.kanban.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace _03.kanban.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected kanbanContext Context;
        internal DbSet<TEntity> dbSet;
        public BaseRepository(kanbanContext context)
        {
            Context = context;
            dbSet = context.Set<TEntity>();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entityResult = await dbSet.FindAsync(id);
            if (entityResult is null)
                return true;
            dbSet.Remove(entityResult);
            return true;
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> express, string[] includes = null)
        {
            var query = dbSet.AsNoTracking().Where(express);
            if (!String.IsNullOrEmpty(includes))
                query = query.DynamicInclude(includes);

            return await query.ToListAsync();
        }
     
        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public TEntity UpdateAsync(TEntity entity)
        {
            dbSet.Update(entity);
            return entity;
        }
    }
}