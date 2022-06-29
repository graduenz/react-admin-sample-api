namespace ReactAdminSample.Domain.Dto.Request
{
    public class GetListRequestDto<TFilter> where TFilter : class
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string? Sort { get; set; }
        public string? Order { get; set; }
        public TFilter? Filter { get; set; }
    }
}
