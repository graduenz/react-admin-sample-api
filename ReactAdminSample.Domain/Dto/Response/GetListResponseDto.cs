namespace ReactAdminSample.Domain.Dto.Response
{
    public class GetListResponseDto<TData> where TData : class
    {
        public IList<TData>? Data { get; set; }
        public int Total { get; set; }
    }
}
