using LojaVirtual.Domain.Entities.DomainCategoria;
using LojaVirtual.Domain.Interfaces.Repositories.DomainCategoria;
using LojaVirtual.Infra.Data.Base;
using LojaVirtual.Infra.Data.Context;

namespace LojaVirtual.Infra.Data.Repositories.DomainCategoira
{
    public class RepositoryCategoria : RepositoryBase<Categoria>, IRepositoryCategoria
    {
        public RepositoryCategoria(LojaVirutalContext context) 
            : base(context)
        {
        }
    }
}