using System.Web.Http;
using LojaVirtual.Infra.CrossCutting.IoC;
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
    }
}