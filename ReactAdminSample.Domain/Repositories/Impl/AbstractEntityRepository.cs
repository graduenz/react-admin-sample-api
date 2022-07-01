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
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteManyAsync(IList<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteOneAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAllAsQueryable()
        {
            return DbSet;
        }

        public async Task<TEntity?> GetOneAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task UpdateManyAsync(IList<TEntity> entities)
        {
            DbSet.UpdateRange(entities);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateOneAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}
