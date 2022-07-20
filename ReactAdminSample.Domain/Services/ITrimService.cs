using ReactAdminSample.Domain.Dto.Filter;
using ReactAdminSample.Domain.Models;

namespace ReactAdminSample.Domain.Services
{
    public interface ITrimService : IEntityService<Trim, TrimFilterDto>
    {
    }
}
