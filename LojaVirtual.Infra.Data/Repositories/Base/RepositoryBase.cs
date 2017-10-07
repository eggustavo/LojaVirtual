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

        public virtual IEnumerable<TEntity> ListarEntidades()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public virtual TEntity ObterEntidade(Guid id)
        {
            return DbSet.Find(id);
        }

        public bool Existe(Func<TEntity, bool> where)
        {
            return DbSet.Any(where);
        }

        public virtual bool Existe(Guid id)
        {
            var entity = DbSet.Find(id);
            return entity != null;
        }

        public virtual void Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Atualizar(TEntity entity)
        {
            //DbSet.AddOrUpdate(entity);
            var entry = Context.Entry(entity);

            //Necessário essa condição, pois podemos ter recuperado a entidade usando o Dapper
            if (entry.State == EntityState.Detached)
                DbSet.Attach(entity);

            entry.State = EntityState.Modified;
        }

        public virtual void Remover(TEntity entity)
        {
            DbSet.Attach(entity);
            DbSet.Remove(entity);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}