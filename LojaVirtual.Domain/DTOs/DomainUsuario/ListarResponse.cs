using System;

namespace LojaVirtual.Domain.DTOs.DomainUsuario
{
    public class ListarResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string UsuarioLogin { get; set; }
        public string Email { get; set; }
        public bool FlagAtivo { get; set; }
    }
}