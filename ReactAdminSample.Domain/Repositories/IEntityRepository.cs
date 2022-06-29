namespace ReactAdminSample.Domain.Repositories
{
    public interface IEntityRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAllAsQueryable();
        Task<TEntity?> GetOneAsync(Guid id);
        Task AddOneAsync(TEntity entity);
        Task AddManyAsync(IList<TEntity> entities);
        Task UpdateOneAsync(TEntity entity);
        Task UpdateManyAsync(IList<TEntity> entities);
        Task DeleteOneAsync(TEntity entity);
        Task DeleteManyAsync(IList<TEntity> entities);
    }
}
