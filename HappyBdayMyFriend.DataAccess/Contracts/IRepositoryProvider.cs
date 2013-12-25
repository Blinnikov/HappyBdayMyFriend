using System;
using System.Data.Entity;
using HappyBdayMyFriend.Model;

namespace HappyBdayMyFriend.DataAccess.Contracts
{
    /// <summary>
    /// Interface for class that can provide repositories by type.
    /// The class may create the repositories dynamically if it is unable
    /// to find one in its cache of repositories.
    /// </summary>
    public interface IRepositoryProvider
    {
        /// <summary>
        /// Gets or sets the <see cref="DbContext"/> with which to initialize a repository
        /// if one must be created.
        /// </summary>
        DbContext DbContext { get; set; }

        /// <summary>
        /// Gets an <see cref="IRepository{T}"/> for entity type, T.
        /// </summary>
        /// <typeparam name="T">
        /// Root entity type of the <see cref="IRepository{T}"/>.
        /// </typeparam>
        /// <returns> The repository. </returns>
        IRepository<T> GetRepositoryForEntityType<T>() where T : class, IEntity;

        /// <summary>
        /// Gets a repository of type T.
        /// </summary>
        /// <typeparam name="T">
        /// Type of the repository, typically a custom repository interface.
        /// </typeparam>
        /// <param name="factory">
        /// An optional repository creation function that takes a <see cref="DbContext"/>
        /// and returns a repository of T. Used if the repository must be created.
        /// </param>
        /// <returns>Type of the repository.</returns>
        T GetRepository<T>(Func<DbContext, object> factory = null) where T : class;

        /// <summary>
        /// Sets the repository to return from this provider.
        /// </summary>
        /// <typeparam name="T"> Type of repository. </typeparam>
        /// <param name="repository"> The repository. </param>
        void SetRepository<T>(T repository);
    }
}