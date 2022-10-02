using HotWalletsTrialApp.DatabaseContext.EntityFramework;
using System.Data.Entity;
using System.Diagnostics;

namespace HotWalletsTrialApp.Models
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private bool _Disposed = false;

        public EfContext context;

        public Repository()
        {
            if (context == null)
                context = new EfContext();
        }

        public void ContextNew()
        {
            Dispose();
            context = new EfContext();
            _Disposed = false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region CRUD
        public bool AddOrUpdate(T entity)
        {
            try
            {
                context.Entry(entity).State = (entity as IEntity).Id == 0 ? EntityState.Added : EntityState.Modified;
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Deleted;
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
            try
            {
                return context.Set<T>().First(x => (x as IEntity).Id == (entity as IEntity).Id);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public ICollection<T> GetAll()
        {
            try
            {
                return context.Set<T>().ToList();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
        #endregion

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_Disposed)
                if (disposing)
                    context.Dispose();
            _Disposed = true;
        }
    }
}
