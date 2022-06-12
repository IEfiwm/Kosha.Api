using System.Net.Http.Headers;
using System.Web.Http;

namespace FishHoghoghi.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            HttpConfigurationExtensions.MapHttpAttributeRoutes(config);

            #region Old Routing

            //HttpRouteCollectionExtensions.MapHttpRoute(config.Routes, "DefaultApi2", "api/{controller}/{action}", new { });

            //HttpRouteCollectionExtensions.MapHttpRoute(config.Routes, "DefaultApi", "api/{controller}/{username}/{password}/{year}/{month}", new
            //{
            //    year = RouteParameter.Optional,
            //    month = RouteParameter.Optional
            //});

            #endregion

            #region New Routing

            HttpRouteCollectionExtensions.MapHttpRoute(config.Routes, "DefaultApi3", "{controller}/{username}", defaults: new { });

            HttpRouteCollectionExtensions.MapHttpRoute(config.Routes, "DefaultApi4", "{controller}/{username}/{password}/{year}/{month}", new
            {
                year = RouteParameter.Optional,
                month = RouteParameter.Optional
            });

            //HttpRouteCollectionExtensions.MapHttpRoute(config.Routes, "DefaultApi5", "server/{controller}/{action}/{username}/{password}/{year}/{month}", defaults: new
            //{
            //    password = RouteParameter.Optional,
            //    year = RouteParameter.Optional,
            //    month = RouteParameter.Optional
            //});

            #endregion 

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}