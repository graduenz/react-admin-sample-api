namespace ReactAdminSample.Domain.Models
{
    public class Trim : IEntity
    {
        public Guid Id { get; set; }
        public Guid ModelId { get; set; }
        public string? Name { get; set; }
        public int Year { get; set; }
        public Model? Model { get; set; }
    }
}
