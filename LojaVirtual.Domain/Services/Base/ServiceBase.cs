using LojaVirtual.Domain.Interfaces.UoW;

namespace LojaVirtual.Domain.Services.Base
{
    public abstract class ServiceBase
    {
        private readonly IUnitOfWork _uok;

        protected ServiceBase(IUnitOfWork uow)
        {
            _uok = uow;
        }

        protected bool Commit()
        {
            return _uok.Commit();
        }
    }
}