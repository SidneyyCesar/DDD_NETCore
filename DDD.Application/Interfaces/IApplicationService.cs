namespace DDD.Application
{
    public interface IApplicationService<TEntity> where TEntity: class
    {
        void Add(TEntity entity);
        TEntity Select(int id);
        IEnumerable<TEntity> List();
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void Dispose();

    }
}