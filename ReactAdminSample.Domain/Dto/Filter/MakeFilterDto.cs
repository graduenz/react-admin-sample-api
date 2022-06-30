namespace ReactAdminSample.Domain.Dto.Filter
{
    public class MakeFilterDto : IEntityFilter
    {
        public IList<Guid>? Ids { get; set; }
        public string? Name { get; set; }
    }
}
