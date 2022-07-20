using ReactAdminSample.Domain.Dto.Filter;
using ReactAdminSample.Domain.Models;

namespace ReactAdminSample.Domain.Services
{
    public interface IModelService : IEntityService<Model, ModelFilterDto>
    {
    }
}
