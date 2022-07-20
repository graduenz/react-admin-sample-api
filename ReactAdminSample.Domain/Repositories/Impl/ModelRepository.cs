using ReactAdminSample.Domain.Models;

namespace ReactAdminSample.Domain.Repositories.Impl
{
    public class ModelRepository : AbstractEntityRepository<Model>, IModelRepository
    {
        public ModelRepository(SampleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
