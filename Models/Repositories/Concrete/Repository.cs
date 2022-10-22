using HotWalletsTrialApp.Models.Abstract;
using HotWalletsTrialApp.Models.Concrete;
using HotWalletsTrialApp.Models.DBContext.EntityFramework;
using HotWalletsTrialApp.Models.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace HotWalletsTrialApp.Models.Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        #region Field
        private bool _Disposed = false;
        private Func<T, bool> filterIsObjectNotDeleted => d => d.EndDate == null ? true : d.EndDate > DateTime.Now;
        #endregion

        #region Property
        public EfContext Context;
        #endregion

        #region CTOR
        public Repository()
        {
            Context ??= new EfContext();
        }
        #endregion

        #region CRUD
        public T Add(T entity)
        {
            try
            {
                return Context.Add<T>(entity).Entity;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                entity.UpdateDate = DateTime.Now;
                Context.Update<T>(entity);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public bool Delete(int id)
        {
            T dEntity = Get(id);
            return Delete(dEntity);
        }

        public T Get(int id)
        {
            try
            {
                return Context.Find<T>(id);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
        #endregion

        #region ExtraFunction
        public bool AddOrUpdate(T entity)
        {
            try
            {
                if (entity.Id != 0)
                    entity.UpdateDate = DateTime.Now;

                Context.Entry<T>(entity).State = entity.Id == 0 ? EntityState.Added : EntityState.Modified;
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public T Get(T entity)
        {
            return Get(entity.Id);
        }

        public T Get(Func<T, bool> filter)
        {
            try
            {
                return Context.Set<T>().First(filter);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public List<T> GetList(Func<T, bool>? filter = null)
        {
            try
            {
                if (filter != null)
                    return Context.Set<T>().Where(w => filterIsObjectNotDeleted(w) && filter(w)).ToList();
                else
                    return Context.Set<T>().Where(w => filterIsObjectNotDeleted(w)).ToList();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public List<T> GetListWithDeleted(Func<T, bool>? filter = null)
        {
            try
            {
                if (filter != null)
                    return Context.Set<T>().Where(filter).ToList();
                else
                    return Context.Set<T>().ToList();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                //Context.Remove<T>(entity);
                entity.EndDate = DateTime.Now;
                Update(entity);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteRange(List<T> entities)
        {
            try
            {
                //Context.RemoveRange(entities);
                foreach (var entity in entities)
                {
                    Delete(entity);
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
        #endregion

        #region ContextMethods
        public bool Save()
        {
            try
            {
                Context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public void ContextNew()
        {
            Dispose();
            Context = new EfContext();
            _Disposed = false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_Disposed)
                if (disposing)
                {
                    Context.Dispose();
                    _Disposed = true;
                }
        }
        #endregion
    }
}
