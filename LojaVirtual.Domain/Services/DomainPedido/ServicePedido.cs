using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using LojaVirtual.Domain.DTOs.DomainPedido;
using LojaVirtual.Domain.Entities.DomainPedido;
using LojaVirtual.Domain.Interfaces.Repositories.DomainPedido;
using LojaVirtual.Domain.Interfaces.Repositories.DomainProduto;
using LojaVirtual.Domain.Interfaces.Repositories.DomainUsuario;
using LojaVirtual.Domain.Interfaces.Services.DomainPedido;
using LojaVirtual.Domain.Interfaces.UoW;
using LojaVirtual.Domain.Services.Base;

namespace LojaVirtual.Domain.Services.DomainPedido
{
    public class ServicePedido : ServiceBase, IServicePedido
    {
        private readonly IRepositoryPedido _repositoryPedido;
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IRepositoryProduto _repositoryProduto;

        public ServicePedido(IRepositoryPedido repositoryPedido,
            IRepositoryUsuario repositoryUsuario,
            IRepositoryProduto repositoryProduto,
            IUnitOfWork uow) 
            : base(uow)
        {
            _repositoryPedido = repositoryPedido;
            _repositoryUsuario = repositoryUsuario;
            _repositoryProduto = repositoryProduto;
        }

        public IEnumerable<ListarResponse> Listar(ListarRequest request)
        {
            return _repositoryPedido.Listar(request.UsuarioId);
        }

        public ListarResponse Obter(ObterRequest request)
        {
            return _repositoryPedido.Obter(request.UsuarioId, request.PedidoId);
        }

        public AdicionarResponse Adicionar(AdicionarRequest request)
        {
            if (request == null)
            {
                AddNotification("Adicionar", "Objeto 'AdicionarRequest' é obrigatório");
                return null;
            }

            var usuario = _repositoryUsuario.ObterEntidade(request.UsuarioId);
            if (usuario == null)
                AddNotification("Usuário", "Usuário não Localizado!");

            var pedido = new Pedido(usuario, request.TaxaEntrega, request.Desconto);

            // Adiciona os itens no pedido
            foreach (var item in request.Itens)
            {
                var produto = _repositoryProduto.ObterEntidade(item.ProdutoId);
                pedido.AdicionarItem(new PedidoItem(produto, item.Quantidade));
            }

            AddNotifications(pedido.Notifications);

            if (Invalid)
                return null;

            pedido.Itens.ToList().ForEach(pedidoItem =>
            {
                _repositoryProduto.Atualizar(pedidoItem.Produto);
            });

            _repositoryPedido.Adicionar(pedido);
            Commit();

            return new AdicionarResponse
            {
                Numero = pedido.Numero,
                Message = "Pedido Inserido com Sucesso!"
            };
        }

        public IReadOnlyCollection<Notification> GetNotifications()
        {
            return Notifications;
        }

        public void Dispose()
        {
            _repositoryPedido.Dispose();
        }
    }
}