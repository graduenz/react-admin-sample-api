namespace ReactAdminSample.Domain.Dto.Response
{
    public class GetManyReferenceResponseDto<TData> where TData : class
    {
        public IList<TData>? Data { get; set; }
        public int Total { get; set; }
    }
}
