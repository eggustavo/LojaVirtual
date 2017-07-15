using LojaVirtual.Domain.Interfaces.Repositories.DomainCategoria;
using LojaVirtual.Domain.Interfaces.Services.DomainCategoria;
using LojaVirtual.Domain.Interfaces.UoW;
using LojaVirtual.Domain.Services.DomainCategoria;
using LojaVirtual.Infra.Data.Context;
using LojaVirtual.Infra.Data.Repositories.DomainCategoira;
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

            //Service
            container.RegisterType<IServiceCategoria, ServiceCategoria>(new HierarchicalLifetimeManager());
        }
    }
}