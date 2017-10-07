using FluentValidator.Validation;
using LojaVirtual.Domain.Base;
using LojaVirtual.Domain.Entities.DomainUsuario;

namespace LojaVirtual.Domain.Contracts.DomainUsuario
{
    public class UsuarioAdicionarValidationContract : IContract
    {
        public ValidationContract Contract { get; }

        public UsuarioAdicionarValidationContract(Usuario usuario, string confirmacaoSenha)
        {
            Contract = new ValidationContract();
            Contract
                .Requires()
                .IsNotNull(usuario.Nome, "Nome", "O Nome deve ser preenchido")
                .IsNotNull(usuario.UsuarioLogin, "UsuarioLogin", "O Usuário para Login deve ser preenchido")
                .IsNotNull(usuario.Senha, "Senha", "A Senha deve ser preenchida")
                .IsNotNull(usuario.Email, "Email", "O Email deve ser preenchido");

            if (Contract.IsValid)
            {
                Contract
                    .Requires()
                    .HasMinLen(usuario.Nome, 5, "çNome", "O Nome deve conter pelo menos 5 caracteres")
                    .HasMaxLen(usuario.Nome, 100, "Nome", "O Nome deve conter no máximo 100 caracteres")
                    .HasMinLen(usuario.UsuarioLogin, 5, "UsuarioLogin",
                        "O Usuário para Login deve conter pelo menos 5 caracteres")
                    .HasMaxLen(usuario.UsuarioLogin, 20, "UsuarioLogin",
                        "O Usuário para Login deve conter no máximo 20 caracteres")
                    .HasMinLen(usuario.Senha, 5, "Senha", "A Senha deve conter pelo menos 5 caracteres")
                    .HasMaxLen(usuario.Senha, 250, "Senha", "A Senha deve conter no máximo 250 caracteres")
                    .AreEquals(usuario.Senha, Encrypt.EncryptPassword(confirmacaoSenha), "Senha",
                        "As senhas não conferem")
                    .HasMinLen(usuario.Email, 10, "Email", "O Email deve conter pelo menos 10 caracteres")
                    .HasMaxLen(usuario.Email, 200, "Email", "O Email deve conter no máximo 200 caracteres")
                    .IsEmail(usuario.Email, "Email", "Email inválido");
            }
        }
    }
}