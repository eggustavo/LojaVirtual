using System;
using System.Collections.Generic;
using LojaVirtual.Domain.DTOs.DomainCategoria;
using LojaVirtual.Domain.Entities.DomainCategoria;
using LojaVirtual.Domain.Interfaces.Repositories.Base;

namespace LojaVirtual.Domain.Interfaces.Repositories.DomainCategoria
{
    public interface IRepositoryCategoria : IRepositoryBase<Categoria>
    {
        IEnumerable<ListarResponse> Listar();
        ListarResponse ObterPorId(Guid id);
    }
}