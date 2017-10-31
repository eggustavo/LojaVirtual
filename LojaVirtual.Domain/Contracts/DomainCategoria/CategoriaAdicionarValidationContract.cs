using FluentValidator.Validation;
using LojaVirtual.Domain.Entities.DomainCategoria;

namespace LojaVirtual.Domain.Contracts.DomainCategoria
{
    public class CategoriaAdicionarValidationContract : IContract
    {
        public ValidationContract Contract { get; }

        public CategoriaAdicionarValidationContract(Categoria categoria)
        {
            Contract = new ValidationContract();
            Contract
                .Requires()
                .IsNotNull(categoria.Descricao, "Descricao", "A Descrição deve ser preenchida");

            if (Contract.Valid)
            {
                Contract
                    .Requires()
                    .HasMinLen(categoria.Descricao, 3, "Descricao", "A Descrição deve conter pelo menos 3 caracteres")
                    .HasMaxLen(categoria.Descricao, 100, "Descricao", "A Descrição deve conter no máximo 100 caracteres");
            }
        }
    }
}