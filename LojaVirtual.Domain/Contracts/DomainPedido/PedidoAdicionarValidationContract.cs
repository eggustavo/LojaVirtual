using FluentValidator.Validation;
using LojaVirtual.Domain.Entities.DomainPedido;

namespace LojaVirtual.Domain.Contracts.DomainPedido
{
    public class PedidoAdicionarValidationContract : IContract
    {
        public ValidationContract Contract { get; }

        public PedidoAdicionarValidationContract(Pedido pedido)
        {
            Contract = new ValidationContract();
            Contract
                .Requires()
                .IsGreaterThan(pedido.TaxaEntrega, 0, "TaxaEntrega", "Taxa de Entrega deve ser maior que Zero")
                .IsGreaterThan(pedido.Desconto, -1, "Desconto", "Desconto dever ser igual ou maio que Zero");
        }
    }
}