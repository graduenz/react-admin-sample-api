namespace ReactAdminSample.Domain.Dto.Response
{
    public class DeleteResponseDto<TData> where TData : class
    {
        public TData? Data { get; set; }
    }
}
