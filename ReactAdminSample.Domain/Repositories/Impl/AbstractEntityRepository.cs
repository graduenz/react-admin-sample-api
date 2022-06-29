using Microsoft.EntityFrameworkCore;

namespace ReactAdminSample.Domain.Repositories.Impl
{
    public abstract class AbstractEntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class
    {
        public AbstractEntityRepository(SampleDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        protected SampleDbContext DbContext { get; }
        protected DbSet<TEntity> DbSet { get; }

        public Task AddManyAsync(IList<TEntity> entities)
        {
            return DbSet.AddRangeAsync(entities);
        }

        public async Task AddOneAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public Task DeleteManyAsync(IList<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public Task DeleteOneAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public IQueryable<TEntity> GetAllAsQueryable()
        {
            return DbSet;
        }

        public async Task<TEntity?> GetOneAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public Task UpdateManyAsync(IList<TEntity> entities)
        {
            DbSet.UpdateRange(entities);
            return Task.CompletedTask;
        }

        public Task UpdateOneAsync(TEntity entity)
        {
            DbSet.Update(entity);
            return Task.CompletedTask;
        }
    }
}
