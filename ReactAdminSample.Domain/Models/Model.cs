namespace ReactAdminSample.Domain.Models
{
    public class Model : IEntity
    {
        public Guid Id { get; set; }
        public Guid MakeId { get; set; }
        public string? Name { get; set; }
        public Make? Make { get; set; }
        public IList<Trim>? Trims { get; set; }
    }
}
