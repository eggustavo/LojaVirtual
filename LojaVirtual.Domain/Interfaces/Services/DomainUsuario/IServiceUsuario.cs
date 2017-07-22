using System;
using System.Collections.Generic;
using LojaVirtual.Domain.DTOs.DomainUsuario;

namespace LojaVirtual.Domain.Interfaces.Services.DomainUsuario
{
    public interface IServiceUsuario : IDisposable
    {
        UsuarioDto ObterPorId(Guid id);
        IEnumerable<UsuarioDto> ListarTodos();
        UsuarioDto Adicionar(UsuarioDto usuarioDto);
        UsuarioDto Atualizar(UsuarioDto usuarioDto);
        UsuarioDto Remover(Guid id);
    }
}