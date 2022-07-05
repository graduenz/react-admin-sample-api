using Microsoft.EntityFrameworkCore;
using ReactAdminSample.Domain.Dto;
using ReactAdminSample.Domain.Dto.Filter;
using ReactAdminSample.Domain.Dto.Request;
using ReactAdminSample.Domain.Extensions;
using ReactAdminSample.Domain.Models;
using ReactAdminSample.Domain.Repositories;

namespace ReactAdminSample.Domain.Services.Impl
{
    public abstract class AbstractEntityService<TEntity, TFilter, TRepository> : IEntityService<TEntity, TFilter>
        where TEntity : class, IEntity, new()
        where TFilter : class, IEntityFilter
        where TRepository : IEntityRepository<TEntity>
    {
        public AbstractEntityService(TRepository repository)
        {
            Repository = repository;
        }

        protected TRepository Repository { get; }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await Repository.AddOneAsync(entity);

            return entity;
        }

        public async Task<TEntity?> DeleteAsync(Guid id)
        {
            var entity = await Repository.GetOneAsync(id);

            if (entity == null)
                return null;

            await Repository.DeleteOneAsync(entity);

            return entity;
        }

        public async Task<IList<Guid>> DeleteManyAsync(IList<Guid> ids)
        {
            var entities = ids.Select(id => new TEntity() { Id = id }).ToList();
            await Repository.DeleteManyAsync(entities);

            return ids;
        }

        public async Task<GetManyResult<TEntity>> GetManyAsync(GetManyRequestDto<TFilter> request)
        {
            var query = Repository.GetAllAsQueryable().AsNoTracking();

            query = ApplyFiltering(query, request);

            var total = await query.CountAsync();

            query = ApplySorting(query, request);

            var toSkip = 0;
            if (request.PageSize > 0)
            {
                toSkip = (request.PageIndex - 1) * request.PageSize;
                query = query.Skip(toSkip).Take(request.PageSize);
            }

            return new GetManyResult<TEntity>() {
                Entities = await query.ToListAsync(),
                RangeStart = toSkip,
                RangeEnd = Math.Min(toSkip + request.PageSize, total),
                Total = total,
            };
        }

        public async Task<TEntity?> GetOneAsync(Guid id)
        {
            return await Repository.GetOneAsync(id);
        }

        public async Task<TEntity?> UpdateAsync(Guid id, TEntity entity)
        {
            var existing = await Repository.GetOneAsync(id);

            if (existing == null)
                return null;

            entity.Id = id;
            await Repository.UpdateOneAsync(entity);

            return entity;
        }

        public async Task<IList<TEntity>> UpdateManyAsync(IList<Guid> ids, TEntity entity)
        {
            var existingIds = await Repository
                .GetAllAsQueryable()
                .AsNoTracking()
                .Where(m => ids.Contains(m.Id))
                .Select(m => m.Id)
                .ToListAsync();

            var entities = existingIds.Select(id =>
            { 
                var copy = entity.DeepCopy();
                copy.Id = id;
                return copy;
            })
            .ToList();

            await Repository.UpdateManyAsync(entities);

            return entities;
        }

        protected abstract IQueryable<TEntity> ApplySpecificFiltering(IQueryable<TEntity> query, GetManyRequestDto<TFilter> request);

        protected virtual IQueryable<TEntity> ApplyFiltering(IQueryable<TEntity> query, GetManyRequestDto<TFilter> request)
        {
            if (request.Filter == null)
                return query;

            if (request.Filter.Ids?.Count > 0) {
                query = query.Where(m => request.Filter.Ids.Contains(m.Id));
            }

            return ApplySpecificFiltering(query, request);
        }

        protected virtual IOrderedQueryable<TEntity> ApplySorting(IQueryable<TEntity> source, GetManyRequestDto<TFilter> request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrEmpty(request.Sort) || string.IsNullOrEmpty(request.Order)) return source.OrderBy("Id");

            return request.Order.Equals("desc", StringComparison.OrdinalIgnoreCase)
                ? source.OrderByDescending(request.Sort)
                : source.OrderBy(request.Sort);
        }
    }
}
