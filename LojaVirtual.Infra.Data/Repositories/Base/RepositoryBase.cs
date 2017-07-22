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

        public TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Atualizar(TEntity entity)
        {
            DbSet.AddOrUpdate(entity);
        }

        public void Remover(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}