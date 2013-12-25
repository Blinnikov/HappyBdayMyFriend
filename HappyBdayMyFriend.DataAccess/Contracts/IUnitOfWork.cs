using HappyBdayMyFriend.Model;
namespace HappyBdayMyFriend.DataAccess.Contracts
{
    /// <summary>
    /// Interface for the "Unit of work" pattern.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets Card repository.
        /// </summary>
        IRepository<Card> Cards { get; }

        /// <summary>
        /// Saves pending changes;
        /// </summary>
        void Commit();
    }
}