﻿using LojaVirtual.Domain.Base;
using LojaVirtual.Domain.Entities.DomainProduto;

namespace LojaVirtual.Domain.Entities.DomainPedido
{
    public class PedidoItem : EntityBase
    {
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public decimal ValorTotal() => ValorUnitario * Quantidade;

        protected PedidoItem() { }

        public PedidoItem(Produto produto, int quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;
            ValorUnitario = produto.Preco;

            produto.DiminuirQuantidadeEstoque(quantidade);
        }
    }
}