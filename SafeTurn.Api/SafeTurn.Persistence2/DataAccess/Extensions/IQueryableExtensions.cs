using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SafeTurn.Persistence.DataAccess.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params string[] includes) where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                    (current, include) => current.Include(include));
            }

            return query;
        }
    }
}
