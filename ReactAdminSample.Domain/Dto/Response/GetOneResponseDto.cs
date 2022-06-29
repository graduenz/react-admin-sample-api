namespace ReactAdminSample.Domain.Dto.Response
{
    public class GetOneResponseDto<TData> where TData : class
    {
        public TData? Data { get; set; }
    }
}
