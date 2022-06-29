namespace ReactAdminSample.Domain.Models
{
    public class Make : IEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public IList<Model>? Models { get; set; }
    }
}
