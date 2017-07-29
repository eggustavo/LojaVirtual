using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LojaVirtual.Domain.DTOs.DomainProduto;
using LojaVirtual.Domain.Interfaces.Services.DomainProduto;

namespace LojaVirtual.WebApi.Controllers.Produto
{
    [RoutePrefix("api")]
    public class ProdutoController : BaseController
    {
        private readonly IServiceProduto _serviceProduto;

        public ProdutoController(IServiceProduto serviceProduto)
        {
            _serviceProduto = serviceProduto;
        }

        [HttpGet]
        [Route("v1/produto")]
        public Task<HttpResponseMessage> Listar()
        {
            return CreateResponse(HttpStatusCode.OK, _serviceProduto.GetNotifications(), _serviceProduto.ListarTodos());
        }

        [HttpGet]
        [Route("v1/produto/{id}")]
        public Task<HttpResponseMessage> ObterPorId(Guid id)
        {
            return CreateResponse(HttpStatusCode.OK, _serviceProduto.GetNotifications(), _serviceProduto.ObterPorId(id));
        }

        [HttpGet]
        [Route("v1/produto-categoria/{idCategoria}")]
        public Task<HttpResponseMessage> ListarPorCategoria(int idCategoria)
        {
            return CreateResponse(HttpStatusCode.OK, _serviceProduto.GetNotifications(), _serviceProduto.ListarPorCategoria(idCategoria));
        }

        [HttpPost]
        [Route("v1/produto")]
        public Task<HttpResponseMessage> Adicionar(ProdutoDto produtoDto)
        {
            _serviceProduto.Adicionar(produtoDto);
            return CreateResponse(HttpStatusCode.Created, _serviceProduto.GetNotifications(), null);
        }

        [HttpPut]
        [Route("v1/produto")]
        public Task<HttpResponseMessage> Atualizar(ProdutoDto produtoDto)
        {
            _serviceProduto.Atualizar(produtoDto);
            return CreateResponse(HttpStatusCode.OK, _serviceProduto.GetNotifications(), null);
        }

        [HttpDelete]
        [Route("v1/produto/{id}")]
        public Task<HttpResponseMessage> Remover(Guid id)
        {
            _serviceProduto.Remover(id);
            return CreateResponse(HttpStatusCode.OK, _serviceProduto.GetNotifications(), null);
        }
    }
}
