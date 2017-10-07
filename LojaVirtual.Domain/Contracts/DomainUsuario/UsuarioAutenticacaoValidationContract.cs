using FluentValidator.Validation;
using LojaVirtual.Domain.Base;
using LojaVirtual.Domain.Entities.DomainUsuario;

namespace LojaVirtual.Domain.Contracts.DomainUsuario
{
    public class UsuarioAutenticacaoValidationContract : IContract
    {
        public ValidationContract Contract { get; }

        public UsuarioAutenticacaoValidationContract(Usuario usuario, string senha)
        {
            Contract = new ValidationContract();
            Contract
                .Requires()
                .AreEquals(usuario.Senha, Encrypt.EncryptPassword(senha), "Senha", "Senha não Confere");
        }
    }
}