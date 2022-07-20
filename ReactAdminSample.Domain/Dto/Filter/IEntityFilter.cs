namespace ReactAdminSample.Domain.Dto.Filter
{
    public interface IEntityFilter
    {
        IList<Guid>? Ids { get; set; }
        string? Search { get; set; }
    }
}
