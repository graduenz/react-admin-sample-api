namespace ReactAdminSample.Domain.Dto.Filter
{
    public abstract class TrimFilterDto : IEntityFilter
    {
        public IList<Guid>? Ids { get; set; }
        public string? Search { get; set; }
        public string? Name { get; set; }
        public int? Year { get; set; }
        public Guid? ModelId { get; set; }
    }
}
