using System;
using System.Collections.Generic;
using System.Linq;
using LojaVirtual.Domain.DTOs.DomainUsuario;
using LojaVirtual.Domain.Entities.DomainUsuario;
using LojaVirtual.Domain.Interfaces.Repositories.DomainUsuario;
using LojaVirtual.Domain.Interfaces.Services.DomainUsuario;

namespace LojaVirtual.Domain.Services.DomainUsuario
{
    public class ServiceUsuario : IServiceUsuario
    {
        private readonly IRepositoryUsuario _repositoryUsuario;

        public ServiceUsuario(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public UsuarioDto ObterPorId(Guid id)
        {
            return (UsuarioDto)_repositoryUsuario.ObterPorId(id);
        }

        public IEnumerable<UsuarioDto> ListarTodos()
        {
            return _repositoryUsuario.ListarTodos().Select(x => (UsuarioDto) x);
        }

        public UsuarioDto Adicionar(UsuarioDto usuarioDto)
        {
            var usuario = new Usuario(usuarioDto);

            if (usuario.IsValid())
                _repositoryUsuario.Adicionar(usuario);

            return usuarioDto;
        }

        public UsuarioDto Atualizar(UsuarioDto usuarioDto)
        {
            var usuario = new Usuario(usuarioDto);

            if (usuario.IsValid())
                _repositoryUsuario.Atualizar(usuario);

            return usuarioDto;
        }

        public UsuarioDto Remover(Guid id)
        {
            var usuario = _repositoryUsuario.ObterPorId(id);

            _repositoryUsuario.Remover(usuario);

            return null;
        }

        public void Dispose()
        {
            _repositoryUsuario.Dispose();
        }
    }
}