using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;

namespace Suvoda.TechnicalTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {



            AutofacConfig();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        private void AutofacConfig()
        {
            var builder = new ContainerBuilder();
            
            var domainAssemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
            builder.RegisterAssemblyModules(domainAssemblies.ToArray());


            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);


            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}
