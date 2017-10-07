using FluentValidator.Validation;
using LojaVirtual.Domain.Entities.DomainProduto;

namespace LojaVirtual.Domain.Contracts.DomainProduto
{
    public class ProdutoAdicionarValidationContract : IContract
    {
        public ValidationContract Contract { get; }

        public ProdutoAdicionarValidationContract(Produto produto)
        {
            Contract = new ValidationContract();
            Contract
                .Requires()
                .IsNotNull(produto.Descricao, "Descricao", "A Descrição deve ser preenchida")
                .IsNotNull(produto.Imagem, "Imagem", "Imagem deve ser inserida");

            if (Contract.IsValid)
            {
                Contract
                    .Requires()
                    .HasMinLen(produto.Descricao, 5, "Descricao", "A Descrição deve conter pelo menos 3 caracteres")
                    .HasMaxLen(produto.Descricao, 100, "Descricao", "A Descrição deve conter no máximo 100 caracteres")
                    .IsGreaterThan(produto.Preco, 0, "Preco", "Preco deve ser maior que 'Zero'");
            }
        }
    }
}