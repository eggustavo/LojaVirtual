namespace LojaVirtual.Domain.DTOs.DomainUsuario
{
    public class AlterarSenhaRequest
    {
        public string Senha { get; set; }
        public string NovaSenha { get; set; }
        public string ConfirmarNovaSenha { get; set; }
    }
}