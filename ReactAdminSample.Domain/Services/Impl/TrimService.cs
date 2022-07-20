using Microsoft.EntityFrameworkCore;
using ReactAdminSample.Domain.Dto.Filter;
using ReactAdminSample.Domain.Dto.Request;
using ReactAdminSample.Domain.Models;
using ReactAdminSample.Domain.Repositories;

namespace ReactAdminSample.Domain.Services.Impl
{
    public class TrimService : AbstractEntityService<Trim, TrimFilterDto, ITrimRepository>, ITrimService
    {
        public TrimService(ITrimRepository repository) : base(repository)
        {
        }

        protected override IQueryable<Trim> ApplySpecificFiltering(IQueryable<Trim> query, GetManyRequestDto<TrimFilterDto> request)
        {
            if (!string.IsNullOrEmpty(request.Filter?.Search))
                query = query.Where(m =>
                    EF.Functions.Like(m.Name, $"%{request.Filter.Search}%")
                    || EF.Functions.Like(m.Year.ToString(), $"%{request.Filter.Search}%")
                );

            if (!string.IsNullOrEmpty(request.Filter?.Name))
                query = query.Where(m => EF.Functions.Like(m.Name, $"%{request.Filter.Name}%"));

            if (request.Filter?.Year != null)
                query = query.Where(m => m.Year == request.Filter.Year);

            if (request.Filter?.ModelId != null)
                query = query.Where(m => m.ModelId == request.Filter.ModelId);

            return query;
        }
    }
}
