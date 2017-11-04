namespace LojaVirtual.Domain.DTOs.DomainUsuario
{
    public class AdicionarRequest
    {
        public string Nome { get; set; }
        public string UsuarioLogin { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complmento { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Uf { get; set; }
    }
}