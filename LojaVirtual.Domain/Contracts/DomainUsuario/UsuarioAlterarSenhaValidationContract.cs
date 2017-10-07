using FluentValidator.Validation;
using LojaVirtual.Domain.Base;
using LojaVirtual.Domain.Entities.DomainUsuario;

namespace LojaVirtual.Domain.Contracts.DomainUsuario
{
    public class UsuarioAlterarSenhaValidationContract : IContract
    {
        public ValidationContract Contract { get; }

        public UsuarioAlterarSenhaValidationContract(string senha, string senhaAtual, string novaSenha, string confirmacaoNovaSenha)
        {
            Contract = new ValidationContract();
            Contract
                .Requires()
                .AreEquals(senha, Encrypt.EncryptPassword(senhaAtual), "Senha", "A senha atual não confere")
                .AreEquals(novaSenha, confirmacaoNovaSenha, "NovaSenha", "As senhas não conferem");
        }
    }
}