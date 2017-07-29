using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
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

        public ServiceProduto(IUnitOfWork uow,
            IRepositoryProduto repositoryProduto,
            IRepositoryCategoria repositoryCategoria) 
            : base(uow)
        {
            _repositoryCategoria = repositoryCategoria;
            _repositoryProduto = repositoryProduto;
        }

        public IEnumerable<ProdutoDto> ListarTodos()
        {
            return _repositoryProduto.ListarTodos().ToList().Select(prod => new ProdutoDto()
            {
                Id = prod.Id,
                Descricao = prod.Descricao,
                Valor = prod.Valor,
                Imagem = prod.Imagem,
                QuantidadeEstoque = prod.QuantidadeEstoque,
                CategoriaId = prod.Categoria.Id
            });
        }

        public IEnumerable<ProdutoDto> ListarPorCategoria(int categoriaId)
        {
            return _repositoryProduto.ListarPorCategoria(categoriaId).ToList().Select(prod => new ProdutoDto()
            {
                Id = prod.Id,
                Descricao = prod.Descricao,
                Valor = prod.Valor,
                Imagem = prod.Imagem,
                QuantidadeEstoque = prod.QuantidadeEstoque,
                CategoriaId = prod.Categoria.Id
            });
        }

        public ProdutoDto ObterPorId(Guid id)
        {
            var produto = _repositoryProduto.ObterPorId(id);

            if (produto != null)
                return (ProdutoDto) produto;

            AddNotification("Produto", "Produto não localizado!");
            return null;
        }

        public void Adicionar(ProdutoDto produtoDto)
        {
            if (produtoDto == null)
            {
                AddNotification("Adicionar Produto","Objeto Produto é obrigatório");
                return;
            }

            var categoria = _repositoryCategoria.ObterPorId(produtoDto.CategoriaId);

            var produto = new Produto(produtoDto.Descricao, produtoDto.Valor, produtoDto.Imagem, produtoDto.QuantidadeEstoque, categoria);

            AddNotifications(produto.Notifications);

            if (!IsValid())
                return;

            _repositoryProduto.Adicionar(produto);
            Commit();
        }

        public void Atualizar(ProdutoDto produtoDto)
        {
            if (produtoDto == null)
            {
                AddNotification("Atualizar Produto", "Objeto Produto é obrigatório");
                return;
            }

            var categoria = _repositoryCategoria.ObterPorId(produtoDto.CategoriaId);
            var produto = _repositoryProduto.ObterPorId(produtoDto.Id);

            produto.Atualizar(produtoDto.Descricao, produtoDto.Valor, produtoDto.Imagem, categoria);

            AddNotifications(produto.Notifications);

            if (!IsValid())
                return;

            _repositoryProduto.Atualizar(produto);
            Commit();
        }

        public void Remover(Guid id)
        {
            var produto = _repositoryProduto.ObterPorId(id);

            if (produto == null)
            {
                AddNotification("Remover Produto", "Produto não localizado");
                return;
            }

            _repositoryProduto.Remover(produto);
            Commit();
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