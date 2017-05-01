using MVVMCrud.Core.Models;
using System.Data.Entity;

namespace MVVMCrud.Data.EF
{
    public class FriendsContext : DbContext
    {
        public FriendsContext() : base("name=FriendsConnection")
        { }

        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new Configurations.FriendConfiguration());
        }
    }
}
