using MVVMCrud.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace MVVMCrud.Data.EF.Configurations
{
    internal class FriendConfiguration : EntityTypeConfiguration<Friend>
    {
        public FriendConfiguration()
        {
            ToTable("Friends");

            HasKey(f => f.Id);
            Property(f => f.Id).HasColumnName("FriendId");

            Property(f => f.Firstname).IsRequired();
            Property(f => f.Lastname).IsRequired();
        }
    }
}
