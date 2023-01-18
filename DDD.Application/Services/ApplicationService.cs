using DDD.Domain.Interfaces.Services;

namespace DDD.Application.Services
{
  public class ApplicationService<TEntity> : IDisposable, IApplicationService<TEntity> where TEntity : class
  {
    private readonly IServiceBase<TEntity> _serviceBase;
    public ApplicationService(IServiceBase<TEntity> serviceBase)
    {
        _serviceBase = serviceBase;
    }
    public void Add(TEntity entity)
    {
        _serviceBase.Add(entity);
    }

    public IEnumerable<TEntity> List()
    {
        return _serviceBase.List();
    }

    public void Remove(TEntity entity)
    {
        _serviceBase.Remove(entity);
    }

    public TEntity Select(int id)
    {
        return _serviceBase.Select(id);
    }

    public void Update(TEntity entity)
    {
        _serviceBase.Update(entity);
    }
    
    public void Dispose()
    {
        _serviceBase.Dispose();
    }
  }
}