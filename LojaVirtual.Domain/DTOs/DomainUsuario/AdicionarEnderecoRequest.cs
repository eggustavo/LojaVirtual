using System;

namespace LojaVirtual.Domain.DTOs.DomainUsuario
{
    public class AdicionarEnderecoRequest
    {
        public string Apelido { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string PontoReferencia { get; set; }
        public Guid UsuarioId { get; set; }
    }
}