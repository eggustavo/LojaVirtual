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
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Categoria> CategoriaSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Customizações Gerais das Propriedades do Contexto
            //1 - Mapeando o Tipo String do C# para o Tipo varchar do Banco de Dados
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //2 - Padronizando o tamanho do campo string no banco de dados, quando o mesmo não for configurado 
            //    dentro das classes de configuração
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            //3 - Configurações de Mapeamento
            modelBuilder.Configurations.Add(new CategoriaMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}