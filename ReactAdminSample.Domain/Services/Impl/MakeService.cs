using ReactAdminSample.Domain.Dto.Filter;
using ReactAdminSample.Domain.Models;
using ReactAdminSample.Domain.Repositories;

namespace ReactAdminSample.Domain.Services.Impl
{
    public class MakeService : AbstractEntityService<Make, MakeFilterDto, IMakeRepository>, IMakeService
    {
        public MakeService(IMakeRepository repository) : base(repository)
        {
        }
    }
}
