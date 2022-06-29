namespace ReactAdminSample.Domain.Dto.Request
{
    public class GetManyReferenceRequestDto<TId, TFilter> : GetListRequestDto<TFilter> where TFilter : class
    {
        public string? Target { get; set; }
        public TId? Id { get; set; }
    }
}
