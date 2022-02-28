using System.Linq.Expressions;

namespace _02.kanban.Application.Interfaces.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> express, string[] includes = null);        
        Task<TEntity> GetByIdAsync(long id);
        Task<bool> DeleteAsync(long id);
        Task<TEntity> InsertAsync(TEntity entity);
        TEntity UpdateAsync(TEntity entity);
    }
}