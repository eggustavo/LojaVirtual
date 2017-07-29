using System.Data.Entity.ModelConfiguration;
using LojaVirtual.Domain.Entities.DomainProduto;

namespace LojaVirtual.Infra.Data.Mappings
{
    public class ProdutoMapping : EntityTypeConfiguration<Produto>
    {
        public ProdutoMapping()
        {
            HasKey(p => p.Id);

            Property(p => p.Descricao)
                .HasMaxLength(200)
                .IsRequired();

            Property(p => p.Valor)
                .HasPrecision(18, 2)
                .IsRequired();

            Property(p => p.Imagem)
                .HasMaxLength(200)
                .IsRequired();

            Property(p => p.QuantidadeEstoque)
                .IsRequired();

            HasRequired(x => x.Categoria)
                .WithMany()
                .Map(x => x.MapKey("CategoriaId"));

            ToTable("LV_Produto");
        }
    }
}