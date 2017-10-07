using System;
using System.Collections.Generic;
using LojaVirtual.Domain.Entities.DomainProduto;
using LojaVirtual.Domain.Interfaces.Repositories.Base;
using LojaVirtual.Domain.DTOs.DomainProduto;

namespace LojaVirtual.Domain.Interfaces.Repositories.DomainProduto
{
    public interface IRepositoryProduto : IRepositoryBase<Produto>
    {
        IEnumerable<ListarResponse> Listar();
        ListarResponse ObterPorId(Guid id);
    }
}