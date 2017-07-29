using System;
using System.Collections.Generic;
using System.Linq;
using LojaVirtual.Domain.Entities.DomainProduto;
using LojaVirtual.Domain.Interfaces.Repositories.DomainProduto;
using LojaVirtual.Infra.Data.Context;
using LojaVirtual.Infra.Data.Repositories.Base;

namespace LojaVirtual.Infra.Data.Repositories.DomainProduto
{
    public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
    {
        public RepositoryProduto(LojaVirutalContext context) 
            : base(context)
        {
        }

        public IEnumerable<Produto> ListarPorCategoria(int categoriaId)
        {
            return DbSet.Include("Categoria").AsNoTracking().Where(p => p.Categoria.Id == categoriaId).ToList();
        }

        public override Produto ObterPorId(Guid id)
        {
            return DbSet.Include("Categoria").FirstOrDefault(p => p.Id == id);
        }

        public override IEnumerable<Produto> ListarTodos()
        {
            return DbSet.Include("Categoria").AsNoTracking().ToList();
        }
    }
}