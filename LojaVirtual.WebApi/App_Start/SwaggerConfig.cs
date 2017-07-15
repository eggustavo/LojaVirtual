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

                //c.OAuth2("oauth2")
                //    .Description("OAuth2 Implicit Grant")
                //    .Flow("implicit")
                //    .AuthorizationUrl(Helpers.GetIssuerUri() + "/connect/authorize")
                //    .Scopes(scopes =>
                //    {
                //        scopes.Add("sampleapi", "try out the sample api");
                //    });


                /*
                c.OAuth2("oauth2")
                    .Description("OAuth2 Implicit Grant")
                    .Flow("implicit")
                    .AuthorizationUrl("http://localhost:58582/api/identity/token")
                    .TokenUrl("http://localhost:58582/api/identity/token")
                    .Scopes(scopes =>
                    {
                        //scopes.Add("read", "Read access to protected resources");
                        //scopes.Add("write", "Write access to protected resources");
                        scopes.Add("sampleapi", "try out the sample api");
                    });

                c.OperationFilter<SwaggerMiddleware>();

                c.BasicAuth("basic").Description("Bearer Token Authentication");
                */



            })
            .EnableSwaggerUi(c =>
            {
                /*
                c.EnableOAuth2Support("sampleapi", "samplerealm", "Swagger UI");
                */
            });
        }
    }
}
