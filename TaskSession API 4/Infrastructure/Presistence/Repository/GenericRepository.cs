using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Presistence.Data;

namespace Presistence.Repository;

public class GenericRepository<TEntity,TKey>: IGenericRepository<TEntity, TKey> where TEntity: BaseEntity<TKey>
{
    private readonly ApplicationDbContext _dbcontext;

    public GenericRepository(ApplicationDbContext context)
    {
        _dbcontext = context;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking) => 
        asNoTracking ? await _dbcontext.Set<TEntity>().AsNoTracking().ToListAsync():await _dbcontext.Set<TEntity>().ToListAsync();

    public async Task<TEntity?> GetByIdAsync(TKey id) => await _dbcontext.Set<TEntity>().FindAsync(id);
    
    public async Task<IEnumerable<TEntity>> GetAllAsync(Specifications<TEntity> specifications)
        =>await ApplySpecification(specifications).ToListAsync();

    public async Task<int> CountAsync(Specifications<TEntity> specifications)
       =>await ApplySpecification(specifications).CountAsync();

    public async Task<TEntity?> GetByIdAsync(Specifications<TEntity> specifications) 
        => await ApplySpecification(specifications).FirstOrDefaultAsync();

    public async Task AddAync(TEntity entity)=>await _dbcontext.Set<TEntity>().AddAsync(entity);

    public void Update(TEntity entity)=>_dbcontext.Set<TEntity>().Update(entity);

    public void Delete(TEntity entity)=>_dbcontext.Set<TEntity>().Remove(entity);
    public IQueryable<TEntity> ApplySpecification(Specifications<TEntity> specifications)
        => SpecificationEvalutor.GetQuery(_dbcontext.Set<TEntity>(), specifications);
}