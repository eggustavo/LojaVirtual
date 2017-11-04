using System;
using System.Collections.Generic;
using FluentValidator;
using LojaVirtual.Domain.DTOs.Base;
using LojaVirtual.Domain.DTOs.DomainCategoria;
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

        public IEnumerable<ListarResponse> Listar()
        {
            return _repositoryCategoria.Listar();
        }

        public ListarResponse ObterPorId(Guid id)
        {
            var categoria = _repositoryCategoria.ObterPorId(id);

            if (categoria != null)
                return categoria;

            AddNotification("Categoria", "Categoria não Localizada!");
            return null;
        }

        public AdicionarResponse Adicionar(AdicionarRequest request)
        {
            if (request == null)
            {
                AddNotification("Adicionar", "Objeto 'AdicionarRequest' é obrigatório");
                return null;
            }

            var categoria = new Categoria(request.Descricao);

            //var categoriaAdicionarValidationContract = new CategoriaAdicionarValidationContract(categoria);
            //AddNotifications(categoriaAdicionarValidationContract.Contract.Notifications);

            AddNotifications(categoria.Notifications);

            if (Invalid)
                return null;

            _repositoryCategoria.Adicionar(categoria);
            Commit();

            return new AdicionarResponse
            {
                Id = categoria.Id,
                Message = "Categoria Inserida com Sucesso!"
            };
        }

        public ResponseBase Atualizar(AtualizarRequest request)
        {
            if (request == null)
            {
                AddNotification("Atualizar", "Objeto 'AtualizarRequest' é obrigatório");
                return null;
            }

            var categoria = _repositoryCategoria.ObterEntidade(request.Id);
            if (categoria == null)
            {
                AddNotification("Categoria", "Categoria não Localizada!");
                return null;
            }

            categoria.Atualizar(request.Descricao);

            //var categoriaAtualizarValidationContract = new CategoriaAtualizarValidationContract(categoria);
            //AddNotifications(categoriaAtualizarValidationContract.Contract.Notifications);
            
            AddNotifications(categoria.Notifications);

            if (Invalid)
                return null;

            _repositoryCategoria.Atualizar(categoria);
            Commit();

            return new ResponseBase
            {
                Message = "Categoria Alterada com Sucesso!"
            };
        }

        public ResponseBase Remover(Guid id)
        {
            var categoria = _repositoryCategoria.ObterEntidade(id);

            if (categoria == null)
            {
                AddNotification("Categoria", "Categoria não Localizada!");
                return null;
            }

            _repositoryCategoria.Remover(categoria);
            Commit();

            return new ResponseBase
            {
                Message = "Categoria Excluída com Sucesso!"
            };
        }

        public IReadOnlyCollection<Notification> GetNotifications()
        {
            return Notifications;
        }

        public void Dispose()
        {
            _repositoryCategoria.Dispose();
        }
    }
}