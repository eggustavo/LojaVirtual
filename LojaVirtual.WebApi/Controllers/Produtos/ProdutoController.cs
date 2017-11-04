using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LojaVirtual.Domain.DTOs.DomainProduto;
using LojaVirtual.Domain.Interfaces.Services.DomainProduto;
using LojaVirtual.WebApi.Controllers.Base;

namespace LojaVirtual.WebApi.Controllers.Produtos
{
    [Authorize]
    [RoutePrefix("api")]
    public class ProdutoController : BaseController
    {
        private readonly IServiceProduto _serviceProduto;

        public ProdutoController(IServiceProduto serviceProduto)
        {
            _serviceProduto = serviceProduto;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("v1/produto/listar")]
        public Task<HttpResponseMessage> Listar()
        {
            return CreateResponse(HttpStatusCode.OK, _serviceProduto.Listar(), _serviceProduto.GetNotifications());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("v1/produto/listar/categoria/{categoriaId}")]
        public Task<HttpResponseMessage> ListarPorCategoria(Guid categoriaId)
        {
            return CreateResponse(HttpStatusCode.OK, _serviceProduto.Listar(categoriaId), _serviceProduto.GetNotifications());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("v1/produto/{id}")]
        public Task<HttpResponseMessage> ObterPorId(Guid id)
        {
            return CreateResponse(HttpStatusCode.OK, _serviceProduto.ObterPorId(id), _serviceProduto.GetNotifications());
        }

        [HttpPost]
        [Route("v1/produto")]
        public Task<HttpResponseMessage> Adicionar(AdicionarRequest request)
        {
            //var result = _serviceProduto.Adicionar(request);
            return CreateResponse(HttpStatusCode.Created, _serviceProduto.Adicionar(request), _serviceProduto.GetNotifications());
        }

        [HttpPut]
        [Route("v1/produto")]
        public Task<HttpResponseMessage> Atualizar(AtualizarRequest request)
        {
            var result = _serviceProduto.Atualizar(request);
            return CreateResponse(HttpStatusCode.OK, result, _serviceProduto.GetNotifications());
        }

        [HttpDelete]
        [Route("v1/produto/{id}")]
        public Task<HttpResponseMessage> Remover(Guid id)
        {
            var result = _serviceProduto.Remover(id);
            return CreateResponse(HttpStatusCode.OK, result, _serviceProduto.GetNotifications());
        }
    }
}
