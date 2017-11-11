using System;
using System.Collections.Generic;
using System.Linq;
using LojaVirtual.Domain.Base;
using LojaVirtual.Domain.Entities.DomainUsuario;

namespace LojaVirtual.Domain.Entities.DomainPedido
{
    public class Pedido : EntityBase
    {
        private readonly List<PedidoItem> _itens;

        public Usuario Usuario { get; private set; }
        public DateTime Data { get; private set; }
        public string Numero { get; private set; }
        public ICollection<PedidoItem> Itens => _itens.ToArray();
        public decimal TaxaEntrega { get; private set; }
        public decimal Desconto { get; private set; }

        //public decimal SubTotal() => Itens.Sum(p => p.ValorTotal);
        //public decimal ValorTotal() => SubTotal() + TaxaEntrega - Desconto;

        public decimal SubTotal
        {
            get => Itens.Sum(p => p.ValorTotal);
            private set { }
        }

        public decimal ValorTotal
        {
            get => SubTotal + TaxaEntrega - Desconto;
            private set { }
        }

        public void AdicionarItem(PedidoItem item)
        {
            AddNotifications(item.Notifications);

            if (Valid)
                _itens.Add(item);
        }

        protected Pedido() { }

        public Pedido(Usuario usuario, decimal taxaEntrega, decimal desconto)
        {
            Usuario = usuario;
            Data = DateTime.Now;
            Numero = Id.ToString().Substring(0,8).ToUpper();
            TaxaEntrega = taxaEntrega;
            Desconto = desconto;
            _itens = new List<PedidoItem>();
        }
    }
}