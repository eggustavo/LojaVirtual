using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FluentValidator;

namespace LojaVirtual.WebApi.Controllers
{
    public abstract class BaseController : ApiController
    {
        public Task<HttpResponseMessage> CreateResponse(HttpStatusCode code, IReadOnlyCollection<Notification> notifications, object dataReturn)
        {
            if (notifications.Any())
            {
                var objRetornoApi = new RetornoApi(false, null, notifications);
                var responseMessage = Request.CreateResponse(HttpStatusCode.BadRequest, objRetornoApi);
                return Task.FromResult(responseMessage);
            }

            try
            {
                var objRetornoApi = new RetornoApi(true, dataReturn, code.ToString(), "Operação Realizada com Sucesso!!!");
                var responseMessage = Request.CreateResponse(code, objRetornoApi);
                return Task.FromResult(responseMessage);
            }
            catch (Exception ex)
            {
                var objRetornoApi = new RetornoApi(false, null, "Erro Interno", $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: ==> Mensagem: {ex.Message} ==> Mensagem Interna: {ex.InnerException?.Message}");
                var responseMessage = Request.CreateResponse(HttpStatusCode.Conflict, objRetornoApi);
                return Task.FromResult(responseMessage);
            }
        }
    }

    internal class RetornoApi
    {
        public bool Success { get; }
        public object DataReturn { get; }
        public Notification[] Notifications { get; }

        public RetornoApi(bool success, object dataReturn, IEnumerable<Notification> notifications)
        {
            Success = success;
            DataReturn = dataReturn;
            Notifications = notifications.ToArray();
        }

        public RetornoApi(bool success, object dataReturn, string propriedade, string mensagem)
        {
            Success = success;
            DataReturn = dataReturn;
            Notifications = new[] {new Notification(propriedade, mensagem)};
        }
    }
}
