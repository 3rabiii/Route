using System.Collections.Concurrent;
using Domain.Contracts;
using Domain.Entities;
using Presistence.Data;

namespace Presistence.Repository;

public class UnitOfWork: IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
   // private Dictionary<string,object> _repositories;
   private ConcurrentDictionary<string,object> _repositories;
    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _repositories = new();
    }
    public async Task<int> SaveChangesAsync()=> await _dbContext.SaveChangesAsync();

    public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        => (IGenericRepository<TEntity, TKey>)_repositories.GetOrAdd(typeof(TEntity).Name,(_)=> new GenericRepository<TEntity, TKey>(_dbContext));
         //var key= typeof(TEntity).Name;
        // if(_repositories.ContainsKey(key))
        //     return (IGenericRepository<TEntity, TKey>)_repositories[key];
        // else
        // {
        //     var repo=new GenericRepository<TEntity, TKey>(_dbContext);
        //     _repositories.Add(key, repo );
        //     return repo;
        // }
    
}