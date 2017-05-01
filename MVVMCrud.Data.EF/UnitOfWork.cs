using MVVMCrud.Core;
using MVVMCrud.Core.Repositories;
using MVVMCrud.Data.EF.Repositories;

namespace MVVMCrud.Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FriendsContext _context;

        public IFriendRepository Friends { get; }

        public UnitOfWork(FriendsContext context)
        {
            _context = context;
            Friends = new FriendRepository(context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
