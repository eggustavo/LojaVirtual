using System;
using System.Collections.Generic;
using FluentValidator;
using LojaVirtual.Domain.Contracts.DomainProduto;
using LojaVirtual.Domain.DTOs.Base;
using LojaVirtual.Domain.DTOs.DomainProduto;
using LojaVirtual.Domain.Entities.DomainProduto;
using LojaVirtual.Domain.Interfaces.Repositories.DomainCategoria;
using LojaVirtual.Domain.Interfaces.Repositories.DomainProduto;
using LojaVirtual.Domain.Interfaces.Services.DomainProduto;
using LojaVirtual.Domain.Interfaces.UoW;
using LojaVirtual.Domain.Services.Base;

namespace LojaVirtual.Domain.Services.DomainProduto
{
    public class ServiceProduto : ServiceBase, IServiceProduto
    {
        private readonly IRepositoryProduto _repositoryProduto;
        private readonly IRepositoryCategoria _repositoryCategoria;

        public ServiceProduto(IRepositoryProduto repositoryProduto,
            IRepositoryCategoria repositoryCategoria,
            IUnitOfWork uow) 
            : base(uow)
        {
            _repositoryProduto = repositoryProduto;
            _repositoryCategoria = repositoryCategoria;
        }

        public IEnumerable<ListarResponse> Listar()
        {
            return _repositoryProduto.Listar();
        }

        public ListarResponse ObterPorId(Guid id)
        {
            var produto = _repositoryProduto.ObterPorId(id);

            if (produto != null)
                return produto;

            AddNotification("Produto", "Produto não Localizado!");
            return null;
        }

        public AdicionarResponse Adicionar(AdicionarRequest request)
        {
            if (request == null)
            {
                AddNotification("Adicionar", "Objeto 'AdicionarRequest' é obrigatório");
                return null;
            }

            var categoria = _repositoryCategoria.ObterEntidade(request.CategoriaId);
            if (categoria == null)
                AddNotification("Categoria", "Categoria não Localizada!");

            var produto = new Produto(request.Descricao, request.Preco, request.Imagem, request.QuantidadeEstoque, categoria);
            var produtoAdicionarValidationContract = new ProdutoAdicionarValidationContract(produto);
            AddNotifications(produtoAdicionarValidationContract.Contract.Notifications);

            if (Invalid)
                return null;

            _repositoryProduto.Adicionar(produto);
            Commit();

            return new AdicionarResponse
            {
                Id = produto.Id
            };
        }

        public ResponseBase Atualizar(AtualizarRequest request)
        {
            if (request == null)
            {
                AddNotification("Adicionar", "Objeto 'AdicionarRequest' é obrigatório");
                return null;
            }

            var produto = _repositoryProduto.ObterEntidade(request.Id);
            if (produto == null)
            {
                AddNotification("Produto", "Produto não Localizado!");
                return null;
            }

            var categoria = _repositoryCategoria.ObterEntidade(request.CategoriaId);
            if (categoria == null)
                AddNotification("Categoria", "Categoria não Localizada!");

            produto.Atualizar(request.Descricao, request.Preco, request.Imagem, request.QuantidadeEstoque, categoria);
            var produtoAtualizarValidationContract = new ProdutoAtualizarValidationContract(produto);
            AddNotifications(produtoAtualizarValidationContract.Contract.Notifications);

            if (Invalid)
                return null;

            _repositoryProduto.Atualizar(produto);
            Commit();

            return new ResponseBase
            {
                Message = "Produto Alterado com Sucesso"
            };
        }

        public ResponseBase Remover(Guid id)
        {
            var produto = _repositoryProduto.ObterEntidade(id);
            if (produto == null)
            {
                AddNotification("Produto", "Produto não Localizado!");
                return null;
            }

            _repositoryProduto.Remover(produto);
            Commit();

            return new ResponseBase
            {
                Message = "Produto Excluído com Sucesso"
            };
        }

        public IReadOnlyCollection<Notification> GetNotifications()
        {
            return Notifications;
        }

        public void Dispose()
        {
            _repositoryProduto.Dispose();
            _repositoryCategoria.Dispose();
        }
    }
}