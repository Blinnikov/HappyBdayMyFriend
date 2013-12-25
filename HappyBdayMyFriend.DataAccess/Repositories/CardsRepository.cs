using System.Data.Entity;
using HappyBdayMyFriend.Model;

namespace HappyBdayMyFriend.DataAccess.Repositories
{
    public class CardsRepository : RepositoryBase<Card>
    {
        public CardsRepository(DbContext context) : base(context)
        {
        }
    }
}