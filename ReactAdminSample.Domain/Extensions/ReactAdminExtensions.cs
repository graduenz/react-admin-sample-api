using ReactAdminSample.Domain.Dto.Request;

namespace ReactAdminSample.Domain.Extensions
{
    public static class ReactAdminExtensions
    {
        public static IOrderedQueryable<TEntity> ApplySorting<TEntity, TFilter>(this IQueryable<TEntity> source, GetListRequestDto<TFilter> request)
            where TFilter : class
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            
            if (string.IsNullOrEmpty(request.Sort) || string.IsNullOrEmpty(request.Order)) return source.OrderBy("Id");

            return request.Order.Equals("desc", StringComparison.OrdinalIgnoreCase)
                ? source.OrderByDescending(request.Sort)
                : source.OrderBy(request.Sort);
        }
    }
}
