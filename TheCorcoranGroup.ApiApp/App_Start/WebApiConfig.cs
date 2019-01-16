using Microsoft.Web.Http.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing;

namespace TheCorcoranGroup.ApiApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //config.Filters.Add(new ValidateModelAttribute());
            // Web API routes
            var constraintResolver = new DefaultInlineConstraintResolver()
            {
                ConstraintMap =
                {
                    ["apiVersion"] = typeof(ApiVersionRouteConstraint)
                }
            };
            config.MapHttpAttributeRoutes(constraintResolver);
            config.AddApiVersioning(
                o =>
                {
                    o.AssumeDefaultVersionWhenUnspecified = true;
                });


            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(
                new Newtonsoft.Json.Converters.StringEnumConverter());

            var xml = GlobalConfiguration.Configuration.Formatters.XmlFormatter;

            xml.UseXmlSerializer = true;

            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;

        }
    }
}
