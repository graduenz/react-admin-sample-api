using ReactAdminSample.Domain.Models;

namespace ReactAdminSample.Domain.Dto
{
    public class GetManyResult<TEntity>
        where TEntity : class, IEntity, new()
    {
        public IList<TEntity>? Entities { get; set; }
        public int RangeStart { get; set; }
        public int RangeEnd { get; set; }
        public int Total { get; set; }
    }
}
