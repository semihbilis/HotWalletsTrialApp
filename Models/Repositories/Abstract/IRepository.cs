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
        T Get(Func<T, bool> filter);
        List<T> GetList(Func<T, bool>? filter = null);
        List<T> GetListWithDeleted(Func<T, bool>? filter = null);
        bool Delete(T entity);
        #endregion
    }
}
