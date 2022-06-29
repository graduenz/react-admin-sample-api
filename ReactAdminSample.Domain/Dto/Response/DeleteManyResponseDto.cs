namespace ReactAdminSample.Domain.Dto.Response
{
    public class DeleteManyResponseDto<TId>
    {
        public IList<TId>? Data { get; set; }
    }
}
