using System;
using LojaVirtual.Domain.Entities.DomainUsuario;

namespace LojaVirtual.Domain.DTOs.DomainUsuario
{
    public class UsuarioEnderecoDto
    {
        public UsuarioEnderecoDto()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Apelido { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string PontoReferencia { get; set; }

        public static explicit operator UsuarioEnderecoDto(UsuarioEndereco usuarioEndereco)
        {
            return new UsuarioEnderecoDto()
            {
                Id = usuarioEndereco.Id,
                Apelido = usuarioEndereco.Apelido,
                Cep = usuarioEndereco.Cep,
                Logradouro = usuarioEndereco.Logradouro,
                Numero = usuarioEndereco.Numero,
                Cidade = usuarioEndereco.Cidade,
                UF = usuarioEndereco.UF,
                Bairro = usuarioEndereco.Bairro,
                Complemento = usuarioEndereco.Complemento,
                PontoReferencia = usuarioEndereco.PontoReferencia
            };
        }
    }
}