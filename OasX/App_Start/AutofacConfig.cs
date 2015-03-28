using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace OasX
{
    public class AutofacConfig
    {
        public static void RegisterIoc() {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof (OasXApplication).Assembly);
            builder.RegisterAssemblyModules(typeof (OasXApplication).Assembly);
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}