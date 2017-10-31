using FluentValidator.Validation;
using LojaVirtual.Domain.Entities.DomainPedido;

namespace LojaVirtual.Domain.Contracts.DomainPedido
{
    public class PedidoItemAdicionarValidationContract : IContract
    {
        public ValidationContract Contract { get; }

        public PedidoItemAdicionarValidationContract(PedidoItem pedidoItem)
        {
            Contract = new ValidationContract();
            Contract
                .Requires()
                .IsGreaterOrEqualsThan(pedidoItem.Quantidade, 1, "Quantidade", "Quantidade deve ser igual ou maior que 1")
                .IsGreaterOrEqualsThan(pedidoItem.Produto.QuantidadeEstoque, pedidoItem.Quantidade, "QuantidadeEstoque",  $"Não temos tantos {pedidoItem.Produto.Descricao}(s) em estoque.");
        }
    }
}