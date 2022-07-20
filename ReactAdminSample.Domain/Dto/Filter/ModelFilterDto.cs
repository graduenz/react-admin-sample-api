namespace ReactAdminSample.Domain.Dto.Filter
{
    public class ModelFilterDto : IEntityFilter
    {
        public IList<Guid>? Ids { get; set; }
        public string? Search { get; set; }
        public string? Name { get; set; }
        public Guid? MakeId { get; set; }
    }
}
