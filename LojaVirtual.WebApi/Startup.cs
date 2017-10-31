using System;
using System.Web.Http;
using LojaVirtual.Domain.Interfaces.Services.DomainUsuario;
using LojaVirtual.Infra.CrossCutting.IoC;
using LojaVirtual.WebApi.OAuthProvider;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using Unity.WebApi;

namespace LojaVirtual.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //Swagger
            SwaggerConfig.Register(config);

            var container = new UnityContainer();

            ConfigurarIoC(config, container);
            ConfigurarWebApi(config);
            ConfigureOAuth(app, container.Resolve<IServiceUsuario>());

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        private void ConfigurarIoC(HttpConfiguration config, UnityContainer container)
        {
            DependecyRegister.Register(container);
            config.DependencyResolver = new UnityDependencyResolver(container);
        }

        private void ConfigurarWebApi(HttpConfiguration config)
        {
            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            var jsonSettings = formatters.JsonFormatter.SerializerSettings;

            jsonSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            jsonSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.MapHttpAttributeRoutes();
        }

        private void ConfigureOAuth(IAppBuilder app, IServiceUsuario serviceUsuario)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/v1/usuario/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(30),
                Provider = new SimpleAuthorizationServerProvider(serviceUsuario)
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}