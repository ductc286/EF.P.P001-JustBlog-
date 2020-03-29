using System.Web.Mvc;
using System.Web.Routing;

namespace IdentitySample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //// Map to: /Post/year/month/title
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
             "Post",
             "Post/{year}/{month}/{title}",
             new { controller = "Post", action = "Details" },
             new { year = @"\d{4}", month = @"\d{2}" },
             new[] { "FA.JustBlog.Controllers" }
             );

            //// Map to: /Category/category
            routes.MapRoute(
               "Category",
               "Category/{category}",
               new { controller = "Post", action = "Category" }
           );

            //// Map to: /Tag/tag
            routes.MapRoute(
                "Tag",
                "Tag/{tag}",
                new { controller = "Post", action = "Tag" }
            );
            routes.MapRoute(
                name: "Default_Post",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Post", action = "Index", id = UrlParameter.Optional },
                new[] { "IdentitySample.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "About"},
                new[] { "IdentitySample.Controllers" }
            );
           
        }
    }
}