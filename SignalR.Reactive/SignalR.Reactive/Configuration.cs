using System;
using Microsoft.AspNet.SignalR;
using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(SignalR.Reactive.Startup))]
namespace SignalR.Reactive
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DependencyResolverContext.Instance = GlobalHost.DependencyResolver;

            if (DependencyResolverContext.Instance == null)
                throw new InvalidOperationException("DependenyResolver must be set to an instance of IDependencyResolver");

            DependencyResolverContext.Instance.EnableRxSupport();

            var config = new HubConfiguration
            {
                EnableDetailedErrors = true
            };

            config.Resolver = DependencyResolverContext.Instance;

            // Any connection or hub wire up and configuration should go here
            app.MapSignalR(config);
        }
    }
}
