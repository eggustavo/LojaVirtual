using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using LojaVirtual.Domain.DTOs.DomainUsuario;
using LojaVirtual.Domain.Interfaces.Services.DomainUsuario;
using Microsoft.Owin.Security.OAuth;

namespace LojaVirtual.WebApi.OAuthProvider
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IServiceUsuario _serviceUsuario;

        public SimpleAuthorizationServerProvider(IServiceUsuario serviceUsuario)
        {
            _serviceUsuario = serviceUsuario;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var autenticarRequest = new AutenticarRequest
            {
                UsuarioLogin = context.UserName,
                Senha = context.Password
            };
 
            var usuario = _serviceUsuario.Autenticar(autenticarRequest);
            if (usuario == null)
            {
                //var msgErro = string.Empty;
                //_serviceUsuario.GetNotifications().ToList().ForEach(notification =>
                //{
                //    msgErro += $"{notification.Property} - {notification.Message} \n";
                //});
                //
                //context.SetError("Erro de Autenticação", msgErro);

                //Feito dessa forma, pois o processo de autenticação do OAuth não liberar os objetos envolvidos do contexto
                context.SetError("Erro de Autenticação", "Usuário ou Senha Inválidos.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            
            //Definindo as Claims
            identity.AddClaim(new Claim("UsuarioId", usuario.Id.ToString()));
            identity.AddClaim(new Claim("UsuarioNome", usuario.Nome));
            identity.AddClaim(new Claim("UsuarioLogin", usuario.UsuarioLogin));
            identity.AddClaim(new Claim("UsuarioEmail", usuario.Email));

            var principal = new GenericPrincipal(identity, new string[] { });
            Thread.CurrentPrincipal = principal;
            context.Validated(identity);
        }
    }
}