using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidator;
using LojaVirtual.Domain.Base;
using LojaVirtual.Domain.DTOs.DomainUsuario;

namespace LojaVirtual.Domain.Entities.DomainUsuario
{
    public class Usuario : EntityBase
    {
        private readonly IList<UsuarioEndereco> _enderecos;

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Cpf { get; private set; }
        public bool Ativo { get; private set; }

        public virtual ICollection<UsuarioEndereco> Enderecos => _enderecos;

        //Construtor EntityFramework
        protected Usuario()
        {
        }

        public Usuario(UsuarioDto usuarioDto)
        {
            Nome = usuarioDto.Nome;
            Email = usuarioDto.Email;
            Senha = EncryptPassword(usuarioDto.Senha);
            Cpf = usuarioDto.Cpf;
            Ativo = true;

            //_enderecos = new List<UsuarioEndereco>();
            _enderecos = usuarioDto.Enderecos.Select(x => new UsuarioEndereco(x)).ToList();

            ValidarNome();
            ValidarSenha(Senha, EncryptPassword(usuarioDto.ConfirmaSenha));
        }

        public bool Autenticar(string email, string senha)
        {
            if (Email == email && Senha == EncryptPassword(senha))
                return true;

            AddNotification("Usuário", "Usuário ou senha inválidos");
            return false;
        }

        public void AlterarSenha(string senhaAtual, string senhaNova, string confirmaSenhaNova)
        {
            if (Senha != EncryptPassword(senhaAtual))
            {
                AddNotification("Usuário", "Senha atual não confere.");
                return;
            }

            if (ValidarSenha(senhaNova, confirmaSenhaNova))
                Senha = EncryptPassword(senhaNova);
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        public void AdicionarEndereco(UsuarioEndereco usuarioEndereco)
        {
            AddNotifications(usuarioEndereco.Notifications);
            if (usuarioEndereco.IsValid())
                _enderecos.Add(usuarioEndereco);
        }

        private void ValidarNome()
        {
            new ValidationContract<Usuario>(this)
                .IsNull(Nome, "Nome deve ser preenchido")
                .HasMinLenght(p => p.Nome, 5, "Tamanho mínimo é de 5 caracteres")
                .HasMaxLenght(p => p.Nome, 150, "Tamanho máximo de 150 caracteres");
        }

        private bool ValidarSenha(string senha, string confirmaSenha)
        {
            if (senha == confirmaSenha)
                return true;

            AddNotification("Usuário", "As senhas não conferem.");
            return false;
        }

        private string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass))
                return "";
            var password = (pass += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
    }
}