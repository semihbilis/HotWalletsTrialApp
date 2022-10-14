using HotWalletsTrialApp.Models.Abstract;
using System.Linq.Expressions;

namespace HotWalletsTrialApp.Models.Repositories.Abstract
{
    public interface IRepository<T> : IDisposable where T : IEntity
    {
        #region CRUD
        T Add(T entity);
        bool Update(T entity);
        bool Delete(int id);
        T Get(int id);
        #endregion

        #region ExtraFunction
        bool AddOrUpdate(T entity);
        T Get(T entity);
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetList();
        List<T> GetList(Expression<Func<T, bool>> filter);
        bool Delete(T entity);
        #endregion
    }
}
