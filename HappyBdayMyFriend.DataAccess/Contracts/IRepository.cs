using System.Linq;
using HappyBdayMyFriend.Model;

namespace HappyBdayMyFriend.DataAccess.Contracts
{
    /// <summary>
    /// Generic repository interface.
    /// </summary>
    /// <typeparam name="T">Type of the repository.</typeparam>
    public interface IRepository<T> where T : class, IEntity
    {
        /// <summary>
        /// Gets all items of type T.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Gets item by id.
        /// </summary>
        /// <param name="id"> Id of the entity. </param>
        /// <returns> The <see cref="T"/>. </returns>
        T GetById(int id);

        /// <summary>
        /// Adds entity to the repository.
        /// </summary>
        /// <param name="entity">The entity of type <see cref="T"/>.</param>
        void Add(T entity);

        /// <summary>
        /// Updates entity in the repository.
        /// </summary>
        /// <param name="entity">The entity of type <see cref="T"/>.</param>
        void Update(T entity);

        /// <summary>
        /// Deletes entity from the repository.
        /// </summary>
        /// <param name="entity">The entity of type <see cref="T"/>.</param>
        void Delete(T entity);

        /// <summary>
        /// Deletes entity from the repository by id.
        /// </summary>
        /// <param name="id"> The id. </param>
        void Delete(int id);
    }
}