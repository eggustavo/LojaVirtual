using FluentValidator.Validation;
using LojaVirtual.Domain.Base;
using LojaVirtual.Domain.Entities.DomainUsuario;

namespace LojaVirtual.Domain.Contracts.DomainUsuario
{
    public class UsuarioAlterarEmailValidationContract : IContract
    {
        public ValidationContract Contract { get; }

        public UsuarioAlterarEmailValidationContract(string email)
        {
            Contract = new ValidationContract();
            Contract
                .Requires()
                .IsNotNull(email, "Email", "O Email deve ser preenchido");

            if (Contract.IsValid)
            {
                Contract
                    .Requires()
                    .HasMinLen(email, 10, "Email", "O Email deve conter pelo menos 10 caracteres")
                    .HasMaxLen(email, 200, "Email", "O Email deve conter no máximo 200 caracteres")
                    .IsEmail(email, "Email", "Email inválido");
            }
        }
    }
}