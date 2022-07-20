using Microsoft.EntityFrameworkCore;
using ReactAdminSample.Domain.Dto.Filter;
using ReactAdminSample.Domain.Dto.Request;
using ReactAdminSample.Domain.Models;
using ReactAdminSample.Domain.Repositories;

namespace ReactAdminSample.Domain.Services.Impl
{
    public class MakeService : AbstractEntityService<Make, MakeFilterDto, IMakeRepository>, IMakeService
    {
        public MakeService(IMakeRepository repository) : base(repository)
        {
        }

        protected override IQueryable<Make> ApplySpecificFiltering(IQueryable<Make> query, GetManyRequestDto<MakeFilterDto> request)
        {
            // UNDONE: is this safe?
            if (!string.IsNullOrEmpty(request.Filter?.Search))
                query = query.Where(m => EF.Functions.Like(m.Name, $"%{request.Filter.Search}%"));

            if (!string.IsNullOrEmpty(request.Filter?.Name))
                query = query.Where(m => EF.Functions.Like(m.Name, $"%{request.Filter.Name}%"));

            return query;
        }
    }
}
