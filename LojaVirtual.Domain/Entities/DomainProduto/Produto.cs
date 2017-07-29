using FluentValidator;
using LojaVirtual.Domain.Base;
using LojaVirtual.Domain.Entities.DomainCategoria;

namespace LojaVirtual.Domain.Entities.DomainProduto
{
    public class Produto : EntityBase
    {
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public virtual Categoria Categoria { get; private set; }

        public void DiminuirQuantidadeEstoque(int quantidadeEstoque) => QuantidadeEstoque -= quantidadeEstoque;

        //Construtor Entity Framework
        protected Produto() { }

        public Produto(string descricao, decimal valor, string imagem, int quantidadeEstoque, Categoria categoria)
        {
            Descricao = descricao;
            Valor = valor;
            Imagem = imagem;
            QuantidadeEstoque = quantidadeEstoque;
            Categoria = categoria;

            new ValidationContract<Produto>(this)
                .IsNotNull(Descricao, "Descrição deve ser preenchido")
                .HasMinLenght(p => p.Descricao, 5, "Tamanho mínimo é de 5 caracteres")
                .HasMaxLenght(p => p.Descricao, 150, "Tamanho máximo de 150 caracteres")
                .IsGreaterThan(p => p.Valor, 0, "Valor deve ser maior que zero")
                .IsGreaterThan(p => p.QuantidadeEstoque, -1, "Quantidade em Estoque deve ser zero ou maior")
                .IsNotNull(Categoria, "Categoria inexistente ou não preenchida");
        }

        public void Atualizar(string descricao, decimal valor, string imagem, Categoria categoria)
        {
            Descricao = descricao;
            Valor = valor;
            Imagem = imagem;
            Categoria = categoria;

            new ValidationContract<Produto>(this)
                .IsNotNull(Descricao, "Descrição deve ser preenchido")
                .HasMinLenght(p => p.Descricao, 5, "Tamanho mínimo é de 5 caracteres")
                .HasMaxLenght(p => p.Descricao, 150, "Tamanho máximo de 150 caracteres")
                .IsGreaterThan(p => p.Valor, 0, "Valor deve ser maior que zero")
                .IsNotNull(Categoria, "Categoria inexistente ou não preenchida");
        }
    }
}