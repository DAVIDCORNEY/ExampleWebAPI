using System.Linq.Expressions;

namespace ExampleWebAPI.Models
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> OrderByCustom<T>(this IQueryable<T> items, string sortBy, string sortOrder)
        {
            var type = typeof(T);
            var expression2 = Expression.Parameter(type, "t");
            var property = type.GetProperty(sortBy);
            var expression1 = Expression.MakeMemberAccess(expression2, property);
            var lambda = Expression.Lambda(expression1, expression2);
            var result = Expression.Call(
                typeof(Queryable),
                sortOrder == "desc" ? "OrderByDescending" : "OrderBy",
                new Type[] { type, property.PropertyType },
                items.Expression,
                Expression.Quote(lambda));

            return items.Provider.CreateQuery<T>(result);
        }
    }
}
