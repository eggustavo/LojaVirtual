using System;
using System.Collections.Generic;
using LojaVirtual.Domain.Entities.DomainCategoria;
using LojaVirtual.Domain.Interfaces.Repositories.DomainCategoria;
using LojaVirtual.Domain.Interfaces.Services.DomainCategoria;
using LojaVirtual.Domain.Interfaces.UoW;
using LojaVirtual.Domain.Services.Base;

namespace LojaVirtual.Domain.Services.DomainCategoria
{
    public class ServiceCategoria : ServiceBase, IServiceCategoria
    {
        private readonly IRepositoryCategoria _repositoryCategoria;

        public ServiceCategoria(IRepositoryCategoria repositoryCategoria,
            IUnitOfWork uow)
            : base(uow)
        {
            _repositoryCategoria = repositoryCategoria;
        }

        public IEnumerable<Categoria> Listar()
        {
            return _repositoryCategoria.ListarTodos();
        }

        public Categoria ObterPorId(Guid id)
        {
            return _repositoryCategoria.ObterPorId(id);
        }

        public void Adicionar(Categoria categoria)
        {
            categoria.Id = 1;
            _repositoryCategoria.Adicionar(categoria);
            Commit();
        }

        public void Atualizar(Categoria categoria)
        {
            _repositoryCategoria.Atualizar(categoria);
            Commit();
        }

        public void Remover(Guid id)
        {
            var categoria = _repositoryCategoria.ObterPorId(id);

            if (categoria == null)
                return;

            _repositoryCategoria.Remover(categoria);
            Commit();
        }

        public void Dispose()
        {
            _repositoryCategoria.Dispose();
        }
    }
}