using MVVMCrud.Core.Models;
using System.Data.Entity;

namespace MVVMCrud.Data.EF
{
    public class FriendsContext : DbContext
    {
        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new Configurations.FriendConfiguration());
        }
    }
}
