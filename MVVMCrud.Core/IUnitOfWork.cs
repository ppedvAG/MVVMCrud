using MVVMCrud.Core.Repositories;
using System;

namespace MVVMCrud.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IFriendRepository Friends { get; }

        int Complete();
    }
}
