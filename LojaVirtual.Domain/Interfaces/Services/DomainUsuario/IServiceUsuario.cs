using System;
using System.Collections.Generic;
using LojaVirtual.Domain.DTOs.DomainUsuario;
using LojaVirtual.Domain.Interfaces.Services.Base;

namespace LojaVirtual.Domain.Interfaces.Services.DomainUsuario
{
    public interface IServiceUsuario : IServiceBase
    {
        UsuarioDto ObterPorId(Guid id);
        IEnumerable<UsuarioDto> ListarTodos();
        UsuarioDto Adicionar(UsuarioDto usuarioDto);
        UsuarioDto Atualizar(UsuarioDto usuarioDto);
        UsuarioDto Remover(Guid id);
    }
}