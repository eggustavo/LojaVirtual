using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using LojaVirtual.Domain.Interfaces.Repositories.Base;
using LojaVirtual.Infra.Data.Context;

namespace LojaVirtual.Infra.Data.Repositories.Base
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected LojaVirutalContext Context;
        protected DbSet<TEntity> DbSet;

        protected RepositoryBase(LojaVirutalContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> ListarTodos()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public bool Existe(Func<TEntity, bool> where)
        {
            return DbSet.Any(where);
        }

        public virtual void Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Atualizar(TEntity entity)
        {
            DbSet.AddOrUpdate(entity);
        }

        public virtual void Remover(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}