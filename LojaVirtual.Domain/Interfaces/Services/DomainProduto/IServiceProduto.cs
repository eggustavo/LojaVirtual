using System;
using System.Collections.Generic;
using LojaVirtual.Domain.DTOs.DomainProduto;
using LojaVirtual.Domain.Interfaces.Services.Base;

namespace LojaVirtual.Domain.Interfaces.Services.DomainProduto
{
    public interface IServiceProduto : IServiceBase
    {
        IEnumerable<ProdutoDto> ListarTodos();
        IEnumerable<ProdutoDto> ListarPorCategoria(int categoriaId);
        ProdutoDto ObterPorId(Guid id);
        void Adicionar(ProdutoDto produtoDto);
        void Atualizar(ProdutoDto produtoDto);
        void Remover(Guid id);
    }
}