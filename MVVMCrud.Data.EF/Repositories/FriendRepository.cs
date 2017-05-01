using MVVMCrud.Core.Models;
using MVVMCrud.Core.Repositories;

namespace MVVMCrud.Data.EF.Repositories
{
    public class FriendRepository : Repository<FriendsContext, Friend>, IFriendRepository
    {
        public FriendRepository(FriendsContext context) 
            : base(context)
        { }
    }
}
