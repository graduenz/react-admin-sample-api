using ReactAdminSample.Domain.Dto;
using ReactAdminSample.Domain.Dto.Filter;
using ReactAdminSample.Domain.Dto.Request;
using ReactAdminSample.Domain.Models;

namespace ReactAdminSample.Domain.Services
{
    public interface IEntityService<TEntity, TFilter>
        where TEntity : class, IEntity, new()
        where TFilter : class, IEntityFilter
    {
        Task<TEntity?> GetOneAsync(Guid id);
        Task<GetManyResult<TEntity>> GetManyAsync(GetManyRequestDto<TFilter> request);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(Guid id, TEntity entity);
        Task<IList<TEntity>> UpdateManyAsync(IList<Guid> ids, TEntity entity);
        Task<TEntity> DeleteAsync(Guid id);
        Task<IList<Guid>> DeleteManyAsync(IList<Guid> ids);
    }
}
