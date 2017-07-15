using System.Collections;
using LojaVirtual.Domain.Entities.DomainUsuario;
using LojaVirtual.Domain.Interfaces.Repositories.Base;

namespace LojaVirtual.Domain.Interfaces.Repositories.DomainUsuario
{
    public interface IRepositoryUsuario : IRepositoryBase<Usuario>
    {
        IEnumerable ListarTodosEnderecos();
        UsuarioEndereco ObterEnderecoPorId();
        UsuarioEndereco Adicionar(UsuarioEndereco entity);
        UsuarioEndereco Atualizar(UsuarioEndereco entity);
        UsuarioEndereco Remover(UsuarioEndereco entity);
    }
}