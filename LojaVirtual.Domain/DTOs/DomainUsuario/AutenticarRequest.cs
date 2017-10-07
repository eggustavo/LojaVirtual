namespace LojaVirtual.Domain.DTOs.DomainUsuario
{
    public class AutenticarRequest
    {
        public string UsuarioLogin { get; set; }
        public string Senha { get; set; }
    }
}