namespace ReactAdminSample.Domain.Dto.Response
{
    public class UpdateManyResponseDto<TId>
    {
        public IList<TId>? Data { get; set; }
    }
}
