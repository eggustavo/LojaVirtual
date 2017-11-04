using FluentValidator.Validation;
using LojaVirtual.Domain.Entities.DomainPedido;

namespace LojaVirtual.Domain.Contracts.DomainPedido
{
    public class PedidoItemAdicionarValidationContract : IContract
    {
        public ValidationContract Contract { get; }
        private readonly PedidoItem _pedidoItem;

        public PedidoItemAdicionarValidationContract(PedidoItem pedidoItem)
        {
            Contract = new ValidationContract();
            _pedidoItem = pedidoItem;
        }

        public void ValidarPedidoItemProduto()
        {
            Contract
                .Requires()
                .IsNotNull(_pedidoItem.Produto, "Produto", "Produto não Localizado!");
        }

        public void ValidarPedidoItemDemaisPropriedades()
        {
            Contract
                .Requires()
                .IsGreaterOrEqualsThan(_pedidoItem.Quantidade, 1, "Quantidade", "Quantidade deve ser igual ou maior que 1")
                .IsGreaterOrEqualsThan(_pedidoItem.Produto.QuantidadeEstoque, _pedidoItem.Quantidade, "QuantidadeEstoque", $"Não temos tantos {_pedidoItem.Produto.Descricao}(s) em estoque.");
        }
    }
}