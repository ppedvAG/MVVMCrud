using MVVMCrud.Core.Models;
using System.Collections.Generic;

namespace MVVMCrud.Core.Repositories
{
    public interface IRepository<TEnity> where TEnity:Entity
    {
        TEnity Get(int id);
        IEnumerable<TEnity> GetAll();

        void Add(TEnity entity);
        void AddRange(IEnumerable<TEnity> entities);
        void Remove(TEnity entity);
        void RemoveRange(IEnumerable<TEnity> entities);
    }
}
