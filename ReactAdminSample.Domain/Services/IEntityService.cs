using ReactAdminSample.Domain.Dto.Request;
using ReactAdminSample.Domain.Dto.Response;
using ReactAdminSample.Domain.Models;

namespace ReactAdminSample.Domain.Services
{
    public interface IEntityService<TEntity, TFilter>
        where TEntity : class, IEntity, new()
        where TFilter : class
    {
        Task<GetListResponseDto<TEntity>> GetListAsync(GetListRequestDto<TFilter> request);
        Task<GetOneResponseDto<TEntity>> GetOneAsync(Guid id);
        Task<GetManyResponseDto<TEntity>> GetManyAsync(IList<Guid> ids);
        Task<GetManyReferenceResponseDto<TEntity>> GetManyReferenceAsync(GetManyReferenceRequestDto<Guid, TFilter> request);
        Task<CreateResponseDto<TEntity>> CreateAsync(TEntity entity);
        Task<UpdateResponseDto<TEntity>> UpdateAsync(TEntity entity);
        Task<UpdateManyResponseDto<TEntity>> UpdateManyAsync(IList<TEntity> entities);
        Task<DeleteResponseDto<TEntity>> DeleteAsync(Guid id);
        Task<DeleteManyResponseDto<Guid>> DeleteManyAsync(IList<Guid> ids);
    }
}
