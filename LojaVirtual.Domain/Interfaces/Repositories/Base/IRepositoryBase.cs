using System;
using System.Collections.Generic;

namespace LojaVirtual.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> ListarEntidades();
        TEntity ObterEntidade(Guid id);
        bool Existe(Func<TEntity, bool> where);
        bool Existe(Guid id);
        void Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        void Remover(TEntity entity);
    }
}