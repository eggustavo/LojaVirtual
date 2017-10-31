using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LojaVirtual.Domain.DTOs.DomainPedido;
using LojaVirtual.Domain.Interfaces.Services.DomainPedido;
using LojaVirtual.WebApi.Controllers.Base;

namespace LojaVirtual.WebApi.Controllers.Pedidos
{
    [RoutePrefix("api")]
    public class PedidoController : BaseController
    {
        private readonly IServicePedido _servicePedido;

        public PedidoController(IServicePedido servicePedido)
        {
            _servicePedido = servicePedido;
        }

        [HttpPost]
        [Route("v1/pedido/listar")]
        public Task<HttpResponseMessage> Listar(ListarRequest request)
        {
            return CreateResponse(HttpStatusCode.OK, _servicePedido.Listar(request), _servicePedido.GetNotifications());
        }

        [HttpPost]
        [Route("v1/pedido/obter")]
        public Task<HttpResponseMessage> Obter(ObterRequest request)
        {
            return CreateResponse(HttpStatusCode.OK, _servicePedido.Obter(request), _servicePedido.GetNotifications());
        }

        [HttpPost]
        [Route("v1/pedido")]
        public Task<HttpResponseMessage> Adicionar(AdicionarRequest request)
        {
            return CreateResponse(HttpStatusCode.Created, _servicePedido.Adicionar(request), _servicePedido.GetNotifications());
        }
    }
}
