using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(SignalR.Reactive.Startup))]
namespace SignalR.Reactive
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}

//[assembly: PreApplicationStartMethod(typeof(SignalR.Reactive.Configuration), "EnableRxSupport")]
//namespace SignalR.Reactive
//{
//    public static class Configuration
//    {
//        public static void EnableRxSupport()
//        {
//            DependencyResolverContext.Instance = GlobalHost.DependencyResolver;
            
//            if (DependencyResolverContext.Instance == null)
//                throw new InvalidOperationException("DependenyResolver must be set to an instance of IDependencyResolver");

//            DependencyResolverContext.Instance.EnableRxSupport();
//            //ToDo 
//            var config = new HubConfiguration
//                {
//                    EnableDetailedErrors = true
//                };

//            config.Resolver = DependencyResolverContext.Instance;

//            RouteTable.Routes.MapHubs(config); 
//            //AspNetBootstrapper.Initialize();

//        }
//    }
//}
