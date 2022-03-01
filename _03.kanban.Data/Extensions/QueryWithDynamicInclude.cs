using Microsoft.EntityFrameworkCore;
namespace _03.kanban.Data.Extension;

 public static class QueryWithDynamicInclude
    {
        public static IQueryable<TEntity> DynamicInclude<TEntity>(this IQueryable<TEntity> source, string includeProperties) where TEntity : class
        {
            string[] includes = includeProperties.Split(';');
            var query = source.AsQueryable();

            foreach (string include in includes)
                query = query.Include(include);

            return query;
        }
    }