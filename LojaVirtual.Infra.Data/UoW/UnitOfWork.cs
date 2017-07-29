using System;
using LojaVirtual.Domain.Interfaces.UoW;
using LojaVirtual.Infra.Data.Context;

namespace LojaVirtual.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LojaVirutalContext _context;

        public UnitOfWork(LojaVirutalContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}