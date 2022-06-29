namespace ReactAdminSample.Domain.Dto.Response
{
    public class GetManyResponseDto<TData> where TData : class
    {
        public IList<TData>? Data { get; set; }
    }
}
