using Microsoft.Owin;
using Newtonsoft.Json.Serialization;
using Owin;
using AppDemo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using AppDemo.Core.Data;
using AppDemo.Api.App_Start;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.WebApi;

[assembly: OwinStartupAttribute(typeof(AppDemo.Api.Startup))]
namespace AppDemo.Api
{
    public class Startup
    {
        IUnityContainer iocContainer;

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfig = new HttpConfiguration();

            ConfigureWebApi(httpConfig);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            ConfigureIoc(app, httpConfig);

            app.UseWebApi(httpConfig);

        }

        private void ConfigureIoc(IAppBuilder app, HttpConfiguration config)
        {
            iocContainer = UnityConfig.GetConfiguredContainer();

            config.DependencyResolver = new UnityHierarchicalDependencyResolver(iocContainer);
        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}