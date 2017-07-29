using LojaVirtual.Domain.Interfaces.Repositories.DomainCategoria;
using LojaVirtual.Domain.Interfaces.Repositories.DomainProduto;
using LojaVirtual.Domain.Interfaces.Services.DomainCategoria;
using LojaVirtual.Domain.Interfaces.Services.DomainProduto;
using LojaVirtual.Domain.Interfaces.UoW;
using LojaVirtual.Domain.Services.DomainCategoria;
using LojaVirtual.Domain.Services.DomainProduto;
using LojaVirtual.Infra.Data.Context;
using LojaVirtual.Infra.Data.Repositories.DomainCategoira;
using LojaVirtual.Infra.Data.Repositories.DomainProduto;
using LojaVirtual.Infra.Data.UoW;
using Microsoft.Practices.Unity;

namespace LojaVirtual.Infra.CrossCutting.IoC
{
    public static class DependecyRegister
    {
        public static void Register(UnityContainer container)
        {
            //Context
            container.RegisterType<LojaVirutalContext, LojaVirutalContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());

            //Repository
            container.RegisterType<IRepositoryCategoria, RepositoryCategoria>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryProduto, RepositoryProduto>(new HierarchicalLifetimeManager());

            //Service
            container.RegisterType<IServiceCategoria, ServiceCategoria>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceProduto, ServiceProduto>(new HierarchicalLifetimeManager());
        }
    }
}