using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LojaVirtual.Domain.DTOs.DomainUsuario;
using LojaVirtual.Domain.Interfaces.Services.DomainUsuario;
using LojaVirtual.WebApi.Controllers.Base;

namespace LojaVirtual.WebApi.Controllers.Usuarios
{
    [RoutePrefix("api")]
    public class UsuarioController : BaseController
    {
        private readonly IServiceUsuario _serviceUsuario;

        public UsuarioController(IServiceUsuario serviceUsuario)
        {
            _serviceUsuario = serviceUsuario;
        }

        [HttpGet]
        [Route("v1/usuario/listar")]
        public Task<HttpResponseMessage> Listar()
        {
            return CreateResponse(HttpStatusCode.OK, _serviceUsuario.Listar(), _serviceUsuario.GetNotifications());
        }

        [HttpGet]
        [Route("v1/usuario/{id}")]
        public Task<HttpResponseMessage> ObterPorId(Guid id)
        {
            return CreateResponse(HttpStatusCode.OK, _serviceUsuario.ObterPorId(id), _serviceUsuario.GetNotifications());
        }

        [HttpPost]
        [Route("v1/usuario")]
        public Task<HttpResponseMessage> Adicionar(AdicionarRequest request)
        {
            return CreateResponse(HttpStatusCode.Created, _serviceUsuario.Adicionar(request), _serviceUsuario.GetNotifications());
        }

        [HttpPost]
        [Route("v1/usuario/autenticar")]
        public Task<HttpResponseMessage> Autenticar(AutenticarRequest request)
        {
            return CreateResponse(HttpStatusCode.Created, _serviceUsuario.Autenticar(request), _serviceUsuario.GetNotifications());
        }

        [Authorize]
        [HttpPut]
        [Route("v1/usuario")]
        public Task<HttpResponseMessage> Atualizar(AtualizarRequest request)
        {
            return CreateResponse(HttpStatusCode.OK, _serviceUsuario.Atualizar(request), _serviceUsuario.GetNotifications());
        }

        [Authorize]
        [HttpPut]
        [Route("v1/usuario/alterar-senha")]
        public Task<HttpResponseMessage> AlterarSenha(AlterarSenhaRequest request)
        {
            return CreateResponse(HttpStatusCode.OK, _serviceUsuario.AlterarSenha(request), _serviceUsuario.GetNotifications());
        }

        [Authorize]
        [HttpPut]
        [Route("v1/usuario/alterar-email")]
        public Task<HttpResponseMessage> AlterarEmail(AlterarEmailRequest request)
        {
            return CreateResponse(HttpStatusCode.OK, _serviceUsuario.AlterarEmail(request), _serviceUsuario.GetNotifications());
        }

        [HttpDelete]
        [Route("v1/usuario/{id}")]
        public Task<HttpResponseMessage> Remover(Guid id)
        {
            return CreateResponse(HttpStatusCode.OK, _serviceUsuario.Remover(id), _serviceUsuario.GetNotifications());
        }

    }
}
