using System;
using System.Collections.Generic;
using LojaVirtual.Domain.DTOs.DomainUsuario;
using LojaVirtual.Domain.Entities.DomainUsuario;
using LojaVirtual.Domain.Interfaces.Repositories.Base;

namespace LojaVirtual.Domain.Interfaces.Repositories.DomainUsuario
{
    public interface IRepositoryUsuario : IRepositoryBase<Usuario>
    {
        IEnumerable<ListarResponse> Listar();
        ListarResponse ObterPorId(Guid id);
        Usuario ObterEntidade(string usuarioLogin);
        bool EmailJaRegistrado(Guid id, string email);
    }
}