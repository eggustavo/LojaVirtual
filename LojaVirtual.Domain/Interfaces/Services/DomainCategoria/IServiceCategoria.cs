using System;
using System.Collections.Generic;
using LojaVirtual.Domain.Entities.DomainCategoria;

namespace LojaVirtual.Domain.Interfaces.Services.DomainCategoria
{
    public interface IServiceCategoria : IDisposable
    {
        IEnumerable<Categoria> Listar();
        Categoria ObterPorId(Guid id);
        void Adicionar(Categoria categoria);
        void Atualizar(Categoria categoria);
        void Remover(Guid id);
    }
}