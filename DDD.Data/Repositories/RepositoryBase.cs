using DDD.Data.Context;
using DDD.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DDD.Data.Repositories
{
  public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity: class
  {
    private readonly ContextSettings _context;

    public RepositoryBase(ContextSettings context)
    {
        this._context = context;
    }
    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
    }

    public IEnumerable<TEntity> List()
    {
        return _context.Set<TEntity>().ToList();  
    }

    public void Remove(TEntity entity)
    {
        _context.Remove(entity);
        _context.SaveChanges();
    }

    public TEntity Select(int id)
    {
        return _context.Set<TEntity>().Find(id);        
    }

    public void Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }    

    public void Dispose()
    {
        //throw new NotImplementedException();
    }
  }
}