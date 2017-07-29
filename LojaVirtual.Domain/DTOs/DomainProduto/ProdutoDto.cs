using System;
using LojaVirtual.Domain.Entities.DomainProduto;

namespace LojaVirtual.Domain.DTOs.DomainProduto
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Imagem { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int CategoriaId { get; set; }

        public static explicit operator ProdutoDto(Produto produto)
        {
            return new ProdutoDto()
            {
                Id = produto.Id,
                Descricao = produto.Descricao,
                Valor = produto.Valor,
                Imagem = produto.Imagem,
                QuantidadeEstoque = produto.QuantidadeEstoque,
                CategoriaId = produto.Categoria.Id
            };
        }
    }
}