using ReactAdminSample.Domain.Models;

namespace ReactAdminSample.Domain.Repositories.Impl
{
    public class TrimRepository : AbstractEntityRepository<Trim>, ITrimRepository
    {
        public TrimRepository(SampleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
