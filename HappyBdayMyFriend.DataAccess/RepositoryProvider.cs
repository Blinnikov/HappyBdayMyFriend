using System;
using System.Collections.Generic;
using System.Data.Entity;
using HappyBdayMyFriend.DataAccess.Contracts;
using HappyBdayMyFriend.Model;

namespace HappyBdayMyFriend.DataAccess
{
    /// <summary>
    /// Provides an <see cref="IRepository{T}"/> for a client request.
    /// </summary>
    /// <remarks>
    /// Caches repositories of a given type so that repositories are only created once per provider.
    /// Code Camper creates a new provider per client request.
    /// </remarks>
    public class RepositoryProvider : IRepositoryProvider
    {
        /// <summary>
        /// The <see cref="RepositoryFactories"/> with which to create a new repository.
        /// </summary>
        /// <remarks>
        /// Should be initialized by constructor injection
        /// </remarks>
        private readonly RepositoryFactories repositoryFactories;

        /// <summary>
        /// Gets the dictionary of repository objects, keyed by repository type.
        /// </summary>
        protected Dictionary<Type, object> Repositories { get; private set; }

        public RepositoryProvider(RepositoryFactories repositoryFactories)
        {
            this.repositoryFactories = repositoryFactories;
            Repositories = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Gets or sets the <see cref="DbContext"/> with which to initialize a repository
        /// if one must be created.
        /// </summary>
        public DbContext DbContext { get; set; }

        /// <summary>
        /// Get or create-and-cache the default <see cref="IRepository{T}"/> for an entity of type T.
        /// </summary>
        /// <typeparam name="T">
        /// Root entity type of the <see cref="IRepository{T}"/>.
        /// </typeparam>
        /// <returns>
        /// The <see cref="IRepository{T}"/> repository. </returns>
        public IRepository<T> GetRepositoryForEntityType<T>() where T : class, IEntity
        {
            return GetRepository<IRepository<T>>(repositoryFactories.GetRepositoryFactoryForEntityType<T>());
        }

        /// <summary>
        /// Get or create-and-cache a repository of type T.
        /// </summary>
        /// <typeparam name="T">
        /// Type of the repository, typically a custom repository interface.
        /// </typeparam>
        /// <param name="factory">
        /// An optional repository creation function that takes a context argument
        /// and returns a repository of T. Used if the repository must be created and
        /// caller wants to specify the specific factory to use rather than one
        /// of the injected <see cref="RepositoryFactories"/>.
        /// </param>
        /// <returns> The <see cref="T"/>. </returns>
        public virtual T GetRepository<T>(Func<DbContext, object> factory = null) where T : class
        {
            // Look for T dictionary cache under typeof(T).
            object repoObj;
            Repositories.TryGetValue(typeof(T), out repoObj);
            if (repoObj != null)
            {
                return (T)repoObj;
            }

            // Not found or null; make one, add to dictionary cache, and return it.
            return MakeRepository<T>(factory, DbContext);
        }

        /// <summary>Make a repository of type T.</summary>
        /// <typeparam name="T">Type of repository to make.</typeparam>
        /// <param name="factory">
        /// Factory with <see cref="DbContext"/> argument. Used to make the repository.
        /// If null, gets factory from <see cref="repositoryFactories"/>.
        /// </param>
        /// <param name="context">
        /// The <see cref="DbContext"/> with which to initialize the repository.
        /// </param>        
        /// <returns> The <see cref="T"/>. </returns>
        protected virtual T MakeRepository<T>(Func<DbContext, object> factory, DbContext context)
        {
            var f = factory ?? repositoryFactories.GetRepositoryFactory<T>();
            if (f == null)
            {
                throw new NotImplementedException("No factory for repository type, " + typeof(T).FullName);
            }
            var repo = (T)f(context);
            Repositories[typeof(T)] = repo;
            return repo;
        }

        /// <summary>
        /// Sets the repository for type T that this provider should return.
        /// </summary>
        /// <typeparam name="T"> Type of repository. </typeparam>
        /// <param name="repository"> The repository. </param>
        public void SetRepository<T>(T repository)
        {
            Repositories[typeof(T)] = repository;
        }
    }
}