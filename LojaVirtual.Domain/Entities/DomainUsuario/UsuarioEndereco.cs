using FluentValidator;
using LojaVirtual.Domain.Base;
using LojaVirtual.Domain.DTOs.DomainUsuario;

namespace LojaVirtual.Domain.Entities.DomainUsuario
{
    public class UsuarioEndereco : EntityBase
    {
        public string Apelido { get; private set; }
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Cidade { get; private set; }
        public string UF { get; private set; }
        public string Bairro { get; private set; }
        public string Complemento { get; private set; }
        public string PontoReferencia { get; private set; }
        public virtual Usuario Usuario { get; private set; }

        //Construtor EntityFramework
        protected UsuarioEndereco()
        {
        }

        public UsuarioEndereco(UsuarioEnderecoDto usuarioEnderecoDto)
        {
            Id = usuarioEnderecoDto.Id;
            Apelido = usuarioEnderecoDto.Apelido;
            Cep = usuarioEnderecoDto.Cep;
            Logradouro = usuarioEnderecoDto.Logradouro;
            Numero = usuarioEnderecoDto.Numero;
            Cidade = usuarioEnderecoDto.Cidade;
            UF = usuarioEnderecoDto.UF;
            Bairro = usuarioEnderecoDto.Bairro;
            Complemento = usuarioEnderecoDto.Complemento;
            PontoReferencia = usuarioEnderecoDto.PontoReferencia;
            //Usuario = usuarioEnderecoDto.Usuario;

            ValidarApelido();
            ValidarCep();
            //Demais Validações
        }

        private void ValidarApelido()
        {
            new ValidationContract<UsuarioEndereco>(this)
                .IsNull(Apelido, "Apelido deve ser preenchido")
                .HasMinLenght(p => p.Apelido, 5, "Tamanho mínimo é de 5 caracteres")
                .HasMaxLenght(p => p.Apelido, 150, "Tamanho máximo é de 150 caracteres");
        }

        private void ValidarCep()
        {
            new ValidationContract<UsuarioEndereco>(this)
                .IsNull(Cep, "Cep deve ser preenchido")
                .HasMinLenght(p => p.Apelido, 9, "Tamanho mínimo é de 9 caracteres")
                .HasMaxLenght(p => p.Apelido, 9, "Tamanho máximo é de 9 caracteres");
        }
    }
}