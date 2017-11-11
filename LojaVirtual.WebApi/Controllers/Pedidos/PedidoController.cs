using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LojaVirtual.Domain.DTOs.DomainPedido;
using LojaVirtual.Domain.Interfaces.Services.DomainPedido;
using LojaVirtual.WebApi.Controllers.Base;

namespace LojaVirtual.WebApi.Controllers.Pedidos
{
    [Authorize]
    [RoutePrefix("api")]
    public class PedidoController : BaseController
    {
        private readonly IServicePedido _servicePedido;

        public PedidoController(IServicePedido servicePedido)
        {
            _servicePedido = servicePedido;
        }

        [HttpGet]
        [Route("v1/pedido/listar")]
        public Task<HttpResponseMessage> Listar()
        {
            return CreateResponse(HttpStatusCode.OK, _servicePedido.Listar(InfoToken.UsuarioId), _servicePedido.GetNotifications());
        }

        [HttpPost]
        [Route("v1/pedido")]
        public Task<HttpResponseMessage> Adicionar(AdicionarRequest request)
        {
            request.UsuarioId = InfoToken.UsuarioId;
            return CreateResponse(HttpStatusCode.Created, _servicePedido.Adicionar(request), _servicePedido.GetNotifications());
        }
    }
}
