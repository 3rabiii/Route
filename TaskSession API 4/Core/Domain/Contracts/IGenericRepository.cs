using Domain.Entities;

namespace Domain.Contracts;

public interface IGenericRepository<TEntity,TKey> where TEntity:BaseEntity<TKey>
{
    public Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking=false);
    public Task<TEntity?> GetByIdAsync(TKey id);
    public Task<IEnumerable<TEntity>> GetAllAsync(Specifications<TEntity> specifications);
    public Task<int> CountAsync(Specifications<TEntity> specifications);
    public Task<TEntity?> GetByIdAsync(Specifications<TEntity> specifications);
    public Task AddAync(TEntity entity);
    public void Update(TEntity entity);
    public void Delete(TEntity entity);
    
}