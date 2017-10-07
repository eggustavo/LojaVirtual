namespace LojaVirtual.Domain.DTOs.DomainUsuario
{
    public class AdicionarRequest
    {
        public string Nome { get; set; }
        public string UsuarioLogin { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
        public string Email { get; set; }
    }
}