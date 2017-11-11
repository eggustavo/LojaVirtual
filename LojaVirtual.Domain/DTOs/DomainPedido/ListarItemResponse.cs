using System;

namespace LojaVirtual.Domain.DTOs.DomainPedido
{
    public class ListarItemResponse
    {
        public Guid PedidoItemId { get; set; }
        public Guid ProdutoId { get; set; }
        public string DescricaoProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}