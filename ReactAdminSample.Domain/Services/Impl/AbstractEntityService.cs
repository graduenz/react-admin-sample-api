using ReactAdminSample.Domain.Dto.Request;
using ReactAdminSample.Domain.Dto.Response;
using ReactAdminSample.Domain.Models;
using ReactAdminSample.Domain.Repositories;

namespace ReactAdminSample.Domain.Services.Impl
{
    public abstract class AbstractEntityService<TEntity, TFilter, TRepository> : IEntityService<TEntity, TFilter>
        where TEntity : class, IEntity, new()
        where TFilter : class
        where TRepository : IEntityRepository<TEntity>
    {
        public AbstractEntityService(TRepository repository)
        {
            Repository = repository;
        }

        protected TRepository Repository { get; }

        public async Task<CreateResponseDto<TEntity>> CreateAsync(TEntity entity)
        {
            await Repository.AddOneAsync(entity);

            return new CreateResponseDto<TEntity>() {
                Data = entity,
            };
        }

        public async Task<DeleteResponseDto<TEntity>> DeleteAsync(Guid id)
        {
            var entity = await Repository.GetOneAsync(id);
            await Repository.DeleteOneAsync(entity);

            return new DeleteResponseDto<TEntity>() {
                Data = entity,
            };
        }

        public async Task<DeleteManyResponseDto<Guid>> DeleteManyAsync(IList<Guid> ids)
        {
            var entities = ids.Select(m => new TEntity() { Id = m }).ToList();
            await Repository.DeleteManyAsync(entities);

            return new DeleteManyResponseDto<Guid>() {
                Data = ids,
            };
        }

        public Task<GetListResponseDto<TEntity>> GetListAsync(GetListRequestDto<TFilter> request)
        {
            // TODO: To be implemented
            throw new NotImplementedException();
        }

        public Task<GetManyResponseDto<TEntity>> GetManyAsync(IList<Guid> ids)
        {
            var entities = Repository.GetAllAsQueryable().Where(m => ids.Contains(m.Id)).ToList();
            
            return Task.FromResult(new GetManyResponseDto<TEntity>() {
                Data = entities,
            });
        }

        public Task<GetManyReferenceResponseDto<TEntity>> GetManyReferenceAsync(GetManyReferenceRequestDto<Guid, TFilter> request)
        {
            // TODO: To be implemented
            throw new NotImplementedException();
        }

        public async Task<GetOneResponseDto<TEntity>> GetOneAsync(Guid id)
        {
            var entity = await Repository.GetOneAsync(id);
            
            return new GetOneResponseDto<TEntity>() {
                Data = entity,
            };
        }

        public async Task<UpdateResponseDto<TEntity>> UpdateAsync(TEntity entity)
        {
            await Repository.UpdateOneAsync(entity);

            return new UpdateResponseDto<TEntity>() {
                Data = entity,
            };
        }

        public async Task<UpdateManyResponseDto<TEntity>> UpdateManyAsync(IList<TEntity> entities)
        {
            await Repository.UpdateManyAsync(entities);

            return new UpdateManyResponseDto<TEntity>() {
                Data = entities,
            };
        }
    }
}
