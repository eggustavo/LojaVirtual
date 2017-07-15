using System.Data.Entity.ModelConfiguration;
using LojaVirtual.Domain.Entities.DomainCategoria;

namespace LojaVirtual.Infra.Data.Mappings
{
    public class CategoriaMapping : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMapping()
        {
            HasKey(p => p.Id);

            Property(p => p.Descricao)
                .HasMaxLength(200)
                .IsRequired();

            ToTable("LV_Categoria");
        }
    }
}