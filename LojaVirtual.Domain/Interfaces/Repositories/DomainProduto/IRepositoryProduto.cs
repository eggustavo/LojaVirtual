using System.Collections.Generic;
using LojaVirtual.Domain.Entities.DomainProduto;
using LojaVirtual.Domain.Interfaces.Repositories.Base;

namespace LojaVirtual.Domain.Interfaces.Repositories.DomainProduto
{
    public interface IRepositoryProduto : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> ListarPorCategoria(int categoriaId);
    }
}