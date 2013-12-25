using System;
using HappyBdayMyFriend.DataAccess.Contracts;
using HappyBdayMyFriend.Model;

namespace HappyBdayMyFriend.DataAccess
{
    /// <summary>
    /// Represents the "Unit of Work" pattern.
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();
            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        private HappyBirthdayDbContext DbContext { get; set; }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        /// <summary>
        /// Gets Card repository.
        /// </summary>
        public IRepository<Card> Cards
        {
            get { return GetRepository<IRepository<Card>>(); }
        }

        /// <summary>
        /// Saves pending changes;
        /// </summary>
        public void Commit()
        {
            DbContext.SaveChanges();
        }

        protected void CreateDbContext()
        {
            DbContext = new HappyBirthdayDbContext();
            DbContext.Configuration.ProxyCreationEnabled = false;
            DbContext.Configuration.LazyLoadingEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }

        private IRepository<T> GetStandardRepository<T>() where T : class, IEntity
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        private T GetRepository<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (DbContext != null)
            {
                DbContext.Dispose();
            }
        }
    }
}