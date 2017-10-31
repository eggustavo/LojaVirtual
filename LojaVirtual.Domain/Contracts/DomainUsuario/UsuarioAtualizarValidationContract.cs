using FluentValidator.Validation;
using LojaVirtual.Domain.Entities.DomainUsuario;

namespace LojaVirtual.Domain.Contracts.DomainUsuario
{
    public class UsuarioAtualizarValidationContract : IContract
    {
        public ValidationContract Contract { get; }

        public UsuarioAtualizarValidationContract(Usuario usuario)
        {
            Contract = new ValidationContract();
            Contract
                .Requires()
                .IsNotNull(usuario.Nome, "Nome", "O Nome deve ser preenchido")
                .IsNotNull(usuario.UsuarioLogin, "UsuarioLogin", "O Usuário para Login deve ser preenchido");

            if (Contract.Valid)
            {
                Contract
                    .Requires()
                    .HasMinLen(usuario.Nome, 5, "Nome", "O Nome deve conter pelo menos 5 caracteres")
                    .HasMaxLen(usuario.Nome, 100, "Nome", "O Nome deve conter no máximo 100 caracteres")
                    .HasMinLen(usuario.UsuarioLogin, 5, "UsuarioLogin", "O Usuário para Login deve conter pelo menos 5 caracteres")
                    .HasMaxLen(usuario.UsuarioLogin, 20, "UsuarioLogin", "O Usuário para Login deve conter no máximo 20 caracteres");
            }
        }
    }
}