using ReactAdminSample.Domain.Dto.Filter;

namespace ReactAdminSample.Domain.Dto.Request
{
    public class GetManyRequestDto<TFilter>
        where TFilter : class, IEntityFilter
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string? Sort { get; set; }
        public string? Order { get; set; }
        public TFilter? Filter { get; set; }
    }
}
