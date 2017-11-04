using System;
using System.Web.Http;
using System.Web.Http.Description;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Filters;
using Swagger.Net.Application;
using Swagger.Net;

namespace LojaVirtual.WebApi
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            config
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "LojaVirtual.WebApi");
                        c.DocumentFilter<AuthTokenOperation>();
                        c.ApiKey("Authorization", "header", "API Autorização");
                        c.AccessControlAllowOrigin("*");
                        c.IncludeAllXmlComments(thisAssembly, AppDomain.CurrentDomain.BaseDirectory);
                        c.UseFullTypeNameInSchemaIds();
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DocumentTitle("Loja Virutal Swagger UI");
                        c.UImaxDisplayedTags(100);
                    });
        }

        private class AuthTokenOperation : IDocumentFilter
        {
            public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
            {
                swaggerDoc.paths.Add("/api/v1/usuario/token", new PathItem
                {
                    
                    post = new Operation
                    {
                        tags = new List<string> { "Usuario" },
                        consumes = new List<string>
                        {
                            "application/x-www-form-urlencoded"
                        },
                        parameters = new List<Parameter> {
                            new Parameter
                            {
                                type = "string",
                                name = "grant_type",
                                required = true,
                                @in = "formData"
                            },
                            new Parameter
                            {
                                type = "string",
                                name = "username",
                                required = true,
                                @in = "formData"
                            },
                            new Parameter
                            {
                                type = "string",
                                name = "password",
                                required = true,
                                @in = "formData"
                            }
                        },
                        responses = new Dictionary<string, Response>
                        {
                            {
                                "200",
                                new Response
                                {
                                    description = "Success",
                                    schema = new Schema
                                    {
                                        type = "object",
                                        properties = new Dictionary<string, Schema>
                                        {
                                            {
                                                "access_token",
                                                new Schema
                                                {
                                                    type = "string"
                                                }
                                            },
                                            {
                                                "token_type",
                                                new Schema
                                                {
                                                    type = "string"
                                                }
                                            },
                                            {
                                                "expires_in",
                                                new Schema
                                                {
                                                    type = "integer"
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                });
            }
        }
    }
}
