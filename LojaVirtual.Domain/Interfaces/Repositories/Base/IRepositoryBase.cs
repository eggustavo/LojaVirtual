﻿using System;
using System.Collections.Generic;

namespace LojaVirtual.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> ListarTodos();
        TEntity ObterPorId(Guid id);
        //bool Existe(Func<TEntity, bool> where);
        void Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        void Remover(TEntity entity);
    }
}