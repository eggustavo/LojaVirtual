using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using LojaVirtual.Domain.Entities.DomainCategoria;
using LojaVirtual.Infra.Data.Mappings;

namespace LojaVirtual.Infra.Data.Context
{
    public class LojaVirutalContext : DbContext
    {
        public LojaVirutalContext()
            : base("LojaVirtualConnectionString")
        {

        }

        public DbSet<Categoria> CategoriaSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new CategoriaMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}