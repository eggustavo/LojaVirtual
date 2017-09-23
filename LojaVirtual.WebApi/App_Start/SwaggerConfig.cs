using System.Web.Http;
using Swashbuckle.Application;

namespace LojaVirtual.WebApi
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "Loja Virtual")
                    .License(l =>
                    {
                        l.Name("MIT");
                        l.Url("http://lojavirtual.com/license");
                    })
                    .Contact(ct =>
                    {
                        ct.Name("Desenvolvido por Eduardo");
                        ct.Email("eggustavo@hotmail..com");
                        ct.Url("http://lojavirutal.com");
                    })
                    .Description("API Loja Virtual")
                    .TermsOfService("Nenhum");
            });
        }
    }
}
