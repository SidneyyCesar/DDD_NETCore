using DDD.Domain.Interfaces.Repositories;
using DDD.Domain.Interfaces.Services;

namespace DDD.Domain.Services
{
  public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
  {
    private readonly IRepositoryBase<TEntity> _repository;

    public ServiceBase(IRepositoryBase<TEntity> repository)
    {
        this._repository = repository;
    }
    public void Add(TEntity entity)
    {
      _repository.Add(entity);
    }
    public IEnumerable<TEntity> List()
    {
      return _repository.List();
    }

    public void Remove(TEntity entity)
    {
      _repository.Remove(entity);
    }

    public TEntity Select(int id)
    {
      return _repository.Select(id);
    }

    public void Update(TEntity entity)
    {
      _repository.Update(entity);
    }

    public void Dispose()
    {
      _repository.Dispose();
    }

  }
}