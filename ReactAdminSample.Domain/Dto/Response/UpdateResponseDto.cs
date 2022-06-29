namespace ReactAdminSample.Domain.Dto.Response
{
    public class UpdateResponseDto<TData> where TData : class
    {
        public TData? Data { get; set; }
    }
}
