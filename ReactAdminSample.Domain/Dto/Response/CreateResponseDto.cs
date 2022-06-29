namespace ReactAdminSample.Domain.Dto.Response
{
    public class CreateResponseDto<TData> where TData : class
    {
        public TData? Data { get; set; }
    }
}
