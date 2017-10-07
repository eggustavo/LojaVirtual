using System;

namespace LojaVirtual.Domain.DTOs.DomainProduto
{
    public class AtualizarRequest
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; }
        public int QuantidadeEstoque { get; set; }
        public Guid CategoriaId { get; set; }
    }
}