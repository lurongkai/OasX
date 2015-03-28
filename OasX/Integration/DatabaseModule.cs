using Autofac;
using OasX.Infrastructure;
using OasX.Membership;

namespace OasX.Integration
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<OasXContext>().InstancePerRequest();
            builder.RegisterType<OasXIdentityDbContext>().InstancePerRequest();
        }
    }
}