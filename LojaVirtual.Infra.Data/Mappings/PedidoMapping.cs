using System.Data.Entity.ModelConfiguration;
using LojaVirtual.Domain.Entities.DomainPedido;

namespace LojaVirtual.Infra.Data.Mappings
{
    public class PedidoMapping : EntityTypeConfiguration<Pedido>
    {
        public PedidoMapping()
        {
            HasKey(p => p.Id);

            Property(p => p.Numero)
                .HasMaxLength(8)
                .IsRequired();

            Property(p => p.Data)
                .IsRequired();

            Property(p => p.Desconto)
                .HasPrecision(18, 2)
                .IsOptional();

            Property(p => p.TaxaEntrega)
                .HasPrecision(18, 2)
                .IsOptional();

            HasMany(p => p.Itens);
            HasRequired(p => p.Usuario).WithMany().Map(m => m.MapKey("UsuarioId"));

            ToTable("LV_Pedido");
        }
    }
}