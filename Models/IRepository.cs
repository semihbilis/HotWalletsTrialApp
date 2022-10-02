namespace HotWalletsTrialApp.Models
{
    public interface IRepository<T> : IDisposable where T : IEntity
    {
        ICollection<T> GetAll();
        T Get(T entity);
        bool AddOrUpdate(T entity);
        bool Delete(T entity);
    }
}
