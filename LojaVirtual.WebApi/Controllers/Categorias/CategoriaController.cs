using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LojaVirtual.Domain.DTOs.DomainCategoria;
using LojaVirtual.Domain.Interfaces.Services.DomainCategoria;
using LojaVirtual.WebApi.Controllers.Base;

namespace LojaVirtual.WebApi.Controllers.Categorias
{
    [RoutePrefix("api")]
    public class CategoriaController : BaseController
    {
        private readonly IServiceCategoria _serviceCategoria;

        public CategoriaController(IServiceCategoria serviceCategoria)
        {
            _serviceCategoria = serviceCategoria;
        }

        [HttpGet]
        [Route("v1/categoria/listar")]
        public Task<HttpResponseMessage> Listar()
        {
            return CreateResponse(HttpStatusCode.OK, _serviceCategoria.Listar(), _serviceCategoria.GetNotifications());
        }

        [HttpGet]
        [Route("v1/categoria/{id}")]
        public Task<HttpResponseMessage> ObterPorId(Guid id)
        {
            return CreateResponse(HttpStatusCode.OK, _serviceCategoria.ObterPorId(id), _serviceCategoria.GetNotifications());
        }

        [HttpPost]
        [Route("v1/categoria")]
        public Task<HttpResponseMessage> Adicionar(AdicionarRequest request)
        {
            var result = _serviceCategoria.Adicionar(request);
            return CreateResponse(HttpStatusCode.Created, result, _serviceCategoria.GetNotifications());
        }

        [HttpPut]
        [Route("v1/categoria")]
        public Task<HttpResponseMessage> Atualizar(AtualizarRequest request)
        {
            var result = _serviceCategoria.Atualizar(request);
            return CreateResponse(HttpStatusCode.OK, result, _serviceCategoria.GetNotifications());
        }

        [HttpDelete]
        [Route("v1/categoria/{id}")]
        public Task<HttpResponseMessage> Remover(Guid id)
        {
            var result = _serviceCategoria.Remover(id);
            return CreateResponse(HttpStatusCode.OK, result, _serviceCategoria.GetNotifications());
        }
    }
}
