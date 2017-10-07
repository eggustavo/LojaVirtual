using System.CodeDom;
using LojaVirtual.Domain.Base;
using LojaVirtual.Domain.Contracts.DomainUsuario;

namespace LojaVirtual.Domain.Entities.DomainUsuario
{
    public class Usuario : EntityBase
    {
        public string Nome { get; private set; }
        public string UsuarioLogin { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public bool FlagAtivo { get; private set; }

        public Usuario(string nome, string usuarioLogin, string senha, string email)
        {
            Nome = nome;
            UsuarioLogin = usuarioLogin;
            Senha = Encrypt.EncryptPassword(senha);
            Email = email;
            FlagAtivo = true;
        }

        protected Usuario() { }

        public void Atualizar(string nome, string usuarioLogin)
        {
            Nome = nome;
            UsuarioLogin = usuarioLogin;
        }

        public void Autenticar(string senha)
        {
            var usuarioAutenticacaoValidatonContract = new UsuarioAutenticacaoValidationContract(this, senha);
            AddNotifications(usuarioAutenticacaoValidatonContract.Contract.Notifications);
        }

        public void AlterarSenha(string senhaAtual, string novaSenha, string confirmacaoNovaSenha)
        {
            var usuarioAlterarSenhaValidationContract = new UsuarioAlterarSenhaValidationContract(Senha, senhaAtual, novaSenha, confirmacaoNovaSenha);
            AddNotifications(usuarioAlterarSenhaValidationContract.Contract.Notifications);

            if (!IsValid)
                return;

            Senha = Encrypt.EncryptPassword(novaSenha);
        }

        public void AlterarEmail(string email)
        {
            var usuarioAlterarEmailValidationContract = new UsuarioAlterarEmailValidationContract(email);
            AddNotifications(usuarioAlterarEmailValidationContract.Contract.Notifications);

            if (!IsValid)
                return;

            Email = email;
        }

        public void Ativar() => FlagAtivo = true;
        public void Desativar() => FlagAtivo = false;
    }
}