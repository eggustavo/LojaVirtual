using System.Data.Entity.ModelConfiguration;
using LojaVirtual.Domain.Entities.DomainUsuario;

namespace LojaVirtual.Infra.Data.Mappings
{
    public class UsuarioMapping : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMapping()
        {
            HasKey(p => p.Id);

            Property(p => p.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.UsuarioLogin)
                .HasMaxLength(20)
                .IsRequired();

            Property(p => p.Senha)
                .HasMaxLength(250)
                .IsRequired();

            Property(p => p.Email)
                .HasMaxLength(200)
                .IsRequired();

            Property(p => p.FlagAtivo)
                .IsRequired();

            ToTable("LV_Usuario");
        }
    }
}