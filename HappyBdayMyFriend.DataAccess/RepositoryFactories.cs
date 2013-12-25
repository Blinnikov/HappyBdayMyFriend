using System;
using System.Collections.Generic;
using System.Data.Entity;
using HappyBdayMyFriend.DataAccess.Contracts;
using HappyBdayMyFriend.DataAccess.Repositories;
using HappyBdayMyFriend.Model;

namespace HappyBdayMyFriend.DataAccess
{
    /// <summary>
    /// Repositories creator.
    /// An instance of this class contains repository factory functions for different types.
    /// Each factory function takes an EF <see cref="DbContext"/> and returns
    /// a repository bound to that context.
    /// </summary>
    public class RepositoryFactories
    {
        /// <summary>
        /// Gets the dictionary of repository factory functions.
        /// </summary>
        private readonly IDictionary<Type, Func<DbContext, object>> repositoryFactories;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryFactories"/> class 
        /// with runtime repository factories. 
        /// </summary>
        public RepositoryFactories()
        {
            repositoryFactories = GetFactories();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryFactories"/> class. 
        /// with an arbitrary collection of factories
        /// </summary>
        /// <param name="factories">
        /// The repository factory functions for this instance. 
        /// </param>
        public RepositoryFactories(IDictionary<Type, Func<DbContext, object>> factories)
        {
            repositoryFactories = factories;
        }

        /// <summary>
        /// Returns the runtime repository factory functions,
        /// each one is a factory for a repository of a particular type.
        /// </summary>
        /// <returns> The <see cref="IDictionary{Type, Func}"/>. </returns>
        private IDictionary<Type, Func<DbContext, object>> GetFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>>
            {
                { typeof(IRepository<Card>), dbContext => new CardsRepository(dbContext) }
            };
        }

        /// <summary>
        /// Gets the repository factory function for the type.
        /// </summary>
        /// <typeparam name="T">Type serving as the repository factory lookup key.</typeparam>
        /// <returns>The repository function if found, else null.</returns>
        public Func<DbContext, object> GetRepositoryFactory<T>()
        {
            Func<DbContext, object> factory;
            repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        /// <summary>
        /// Gets the factory for <see cref="IRepository{T}"/> where T is an entity type.
        /// </summary>
        /// <typeparam name="T">The root type of the repository, typically an entity type.</typeparam>
        /// <returns>
        /// A factory that creates the <see cref="IRepository{T}"/>, given an EF <see cref="DbContext"/>.
        /// </returns>
        public Func<DbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class, IEntity
        {
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        /// <summary>
        /// Default factory for a <see cref="IRepository{T}"/> where T is an entity.
        /// </summary>
        /// <typeparam name="T"> Type of the repository's root entity </typeparam>
        /// <returns> The <see cref="Func"/>. </returns>
        protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T>() where T : class, IEntity
        {
            return dbContext => new RepositoryBase<T>(dbContext);
        }
    }
}