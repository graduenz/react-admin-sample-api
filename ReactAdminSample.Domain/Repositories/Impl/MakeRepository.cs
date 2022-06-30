using ReactAdminSample.Domain.Models;

namespace ReactAdminSample.Domain.Repositories.Impl
{
    public class MakeRepository : AbstractEntityRepository<Make>, IMakeRepository
    {
        public MakeRepository(SampleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
