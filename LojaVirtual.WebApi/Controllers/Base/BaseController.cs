using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using FluentValidator;

namespace LojaVirtual.WebApi.Controllers.Base
{
    public abstract class BaseController : ApiController
    {
        protected InformacaoToken InfoToken { get; }

        protected BaseController()
        {
            InfoToken = ObterInformacaoToken();
        }

        protected Task<HttpResponseMessage> CreateResponse(HttpStatusCode code, object dataReturn, IReadOnlyCollection<Notification> notifications)
        {
            if (notifications.Any())
            {
                var responseMessage = Request.CreateResponse(HttpStatusCode.BadRequest, new RetornoApi
                {
                    Success = false,
                    DataReturn = null,
                    Notifications = notifications.ToArray()
                });
                return Task.FromResult(responseMessage);
            }

            try
            {
                var responseMessage = Request.CreateResponse(code, new RetornoApi
                {
                    Success = true,
                    DataReturn = dataReturn,
                    Notifications = null
                });
                return Task.FromResult(responseMessage);
            }
            catch (Exception ex)
            {
                var responseMessage = Request.CreateResponse(HttpStatusCode.Conflict, new RetornoApi
                {
                    Success = false,
                    DataReturn = null,
                    Notifications = new[]
                    {
                        new Notification("Erro Interno", $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: ==> Mensagem: {ex.Message} ==> Mensagem Interna: {ex.InnerException?.Message}")
                    }
                });
                return Task.FromResult(responseMessage);
            }
        }

        private InformacaoToken ObterInformacaoToken()
        {
            if (!User.Identity.IsAuthenticated)
                return null;

            return new InformacaoToken(Guid.Parse(((ClaimsPrincipal)User).Claims.FirstOrDefault(p => p.Type == "UsuarioId")?.Value),
                ((ClaimsPrincipal)User).Claims.FirstOrDefault(p => p.Type == "UsuarioNome")?.Value,
                ((ClaimsPrincipal)User).Claims.FirstOrDefault(p => p.Type == "UsuarioLogin")?.Value,
                ((ClaimsPrincipal)User).Claims.FirstOrDefault(p => p.Type == "UsuarioEmail")?.Value);
        }
    }

    internal class RetornoApi
    {
        public bool Success { get; set; }
        public object DataReturn { get; set; }
        public Notification[] Notifications { get; set; }
    }

    public class InformacaoToken
    {
        public Guid UsuarioId { get; }
        public string UsuarioNome { get; }
        public string UsuarioLogin { get; }
        public string UsuarioEmail { get; }

        public InformacaoToken(Guid usuarioId, string usuarioNome, string usuarioLogin, string usuarioEmail)
        {
            UsuarioId = usuarioId;
            UsuarioNome = usuarioNome;
            UsuarioLogin = usuarioLogin;
            UsuarioEmail = usuarioEmail;
        }
    }
}