using HappyBdayMyFriend.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HappyBdayMyFriend.DataAccess
{
    public class HappyBirthdayDbContext : DbContext
    {
        public HappyBirthdayDbContext() : base(nameOrConnectionString: "Blinnikov_5") { }

        public DbSet<Card> Cards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
