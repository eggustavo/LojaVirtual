using System;

namespace LojaVirtual.Domain.DTOs.DomainPedido
{
    public class ObterRequest
    {
        public Guid UsuarioId { get; set; }
        public Guid PedidoId { get; set; }
    }
}