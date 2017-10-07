using System;

namespace LojaVirtual.Domain.DTOs.DomainUsuario
{
    public class AtualizarRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string UsuarioLogin { get; set; }
    }
}