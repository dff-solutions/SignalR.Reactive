using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SignalR.Reactive.Demo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            
            //HOT STUFF
            //We have a serverside IObservable<string> that gets published on the client side

            //Observable
            //    .Interval(TimeSpan.FromSeconds(1))
            //    .Select(_ => DateTime.Now.ToLongTimeString())
            //    .ToClientside().Observable<RxHub>("SomeValue");
        }

    }
}