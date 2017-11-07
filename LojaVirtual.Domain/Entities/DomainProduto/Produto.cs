using LojaVirtual.Domain.Base;
using LojaVirtual.Domain.Entities.DomainCategoria;

namespace LojaVirtual.Domain.Entities.DomainProduto
{
    public class Produto : EntityBase
    {
        public Produto(string descricao, decimal preco, string imagem, int quantidadeEstoque, Categoria categoria)
        {
            Descricao = descricao;
            Preco = preco;
            Imagem = imagem;
            QuantidadeEstoque = quantidadeEstoque;
            Categoria = categoria;
        }

        public void Atualizar(string descricao, decimal preco, string imagem, int quantidadeEstoque, Categoria categoria)
        {
            Descricao = descricao;
            Preco = preco;
            Imagem = imagem;
            QuantidadeEstoque = quantidadeEstoque;
            Categoria = categoria;
        }

        protected Produto() { }

        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public Categoria Categoria { get; private set; }

        public void DiminuirQuantidadeEstoque(int quantidade) => 
            QuantidadeEstoque -= quantidade;

        //Forma Tradicional
        //public void DiminuirQuantidadeEstoque(int quantidade)
        //{
        //    QuantidadeEstoque = QuantidadeEstoque - quantidade;
        //}
    }
}