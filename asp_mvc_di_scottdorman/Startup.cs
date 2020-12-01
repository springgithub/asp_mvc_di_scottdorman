using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
using asp_mvc_di_scottdorman.code;
using System.Web.Mvc;
using System.Linq;
using System;


//   https://scottdorman.blog/2016/03/17/integrating-asp-net-core-dependency-injection-in-mvc-4/
//  https://benscabbia.co.uk/programming/dependency-injection-asp-net-mvc-5

[assembly: OwinStartupAttribute(typeof(asp_mvc_di_scottdorman.Startup))]
namespace asp_mvc_di_scottdorman
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var services = new ServiceCollection();
            ConfigureServices(services);


            var resolver = new DefaultDependencyResolver(services.BuildServiceProvider());
            DependencyResolver.SetResolver(resolver);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersAsServices(typeof(Startup).Assembly.GetExportedTypes()
   .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
   .Where(t => typeof(IController).IsAssignableFrom(t)
      || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));
        }

    }

}
