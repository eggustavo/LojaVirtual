using System.Reflection.Emit;
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
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complmento { get; private set; }
        public string Bairro { get; private set; }
        public string Municipio { get; private set; }
        public string Uf { get; private set; }
        public bool FlagAdministrador { get; private set; }

        public Usuario(string nome, string usuarioLogin, string senha, string email, string cep, string logradouro, string numero, string complemento, string bairro, string municipio, string uf)
        {
            Nome = nome;
            UsuarioLogin = usuarioLogin;
            Senha = Encrypt.EncryptPassword(senha);
            Email = email;
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complmento = complemento;
            Bairro = bairro;
            Municipio = municipio;
            Uf = uf;
            FlagAdministrador = false;
        }

        protected Usuario() { }

        public void Atualizar(string nome, string usuarioLogin)
        {
            Nome = nome;
            UsuarioLogin = usuarioLogin;
        }

        public bool Autenticar(string senha)
        {
            var usuarioAutenticacaoValidatonContract = new UsuarioAutenticacaoValidationContract(this, senha);
            //AddNotifications(usuarioAutenticacaoValidatonContract.Contract.Notifications);
            return usuarioAutenticacaoValidatonContract.Contract.Valid;
        }

        public void AlterarSenha(string senhaAtual, string novaSenha, string confirmacaoNovaSenha)
        {
            var usuarioAlterarSenhaValidationContract = new UsuarioAlterarSenhaValidationContract(Senha, senhaAtual, novaSenha, confirmacaoNovaSenha);
            AddNotifications(usuarioAlterarSenhaValidationContract.Contract.Notifications);

            if (Invalid)
                return;

            Senha = Encrypt.EncryptPassword(novaSenha);
        }
    }
}