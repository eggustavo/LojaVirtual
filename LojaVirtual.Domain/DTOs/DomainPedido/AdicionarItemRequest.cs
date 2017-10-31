using System;

namespace LojaVirtual.Domain.DTOs.DomainPedido
{
    public class AdicionarItemRequest
    {
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}