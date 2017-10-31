using System;
using System.Collections.Generic;

namespace LojaVirtual.Domain.DTOs.DomainPedido
{
    public class AdicionarRequest
    {
        public Guid UsuarioId { get; set; }
        public decimal TaxaEntrega { get; set; }
        public decimal Desconto { get; set; }
        public IEnumerable<AdicionarItemRequest> Itens { get; set; }
    }
}