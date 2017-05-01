using MVVMCrud.Core.Models;
using MVVMCrud.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MVVMCrud.Data.EF.Repositories
{
    public abstract class Repository<TContext, TEntity> : IRepository<TEntity>
        where TContext : DbContext
        where TEntity : Entity
    {
        protected TContext Context { get; }
        protected DbSet<TEntity> Entries { get; }

        public Repository(TContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context), "Context must not be Null!");

            Context = context;
            Entries = context.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return Entries.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Entries.ToList();
        }

        public void Add(TEntity entity)
        {
            Entries.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Entries.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Entries.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Entries.RemoveRange(entities);
        }
    }
}
