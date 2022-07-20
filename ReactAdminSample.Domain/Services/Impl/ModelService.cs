using Microsoft.EntityFrameworkCore;
using ReactAdminSample.Domain.Dto.Filter;
using ReactAdminSample.Domain.Dto.Request;
using ReactAdminSample.Domain.Models;
using ReactAdminSample.Domain.Repositories;

namespace ReactAdminSample.Domain.Services.Impl
{
    public class ModelService : AbstractEntityService<Model, ModelFilterDto, IModelRepository>, IModelService
    {
        public ModelService(IModelRepository repository) : base(repository)
        {
        }

        protected override IQueryable<Model> ApplySpecificFiltering(IQueryable<Model> query, GetManyRequestDto<ModelFilterDto> request)
        {
            if (!string.IsNullOrEmpty(request.Filter?.Search))
                query = query.Where(m =>
                    EF.Functions.Like(m.Name, $"%{request.Filter.Search}%")
                    || EF.Functions.Like(m.Make.Name, $"%{request.Filter.Search}%")
                );

            if (!string.IsNullOrEmpty(request.Filter?.Name))
                query = query.Where(m => EF.Functions.Like(m.Name, $"%{request.Filter.Name}%"));

            if (request.Filter?.MakeId != null)
                query = query.Where(m => m.MakeId == request.Filter.MakeId);

            return query;
        }
    }
}
