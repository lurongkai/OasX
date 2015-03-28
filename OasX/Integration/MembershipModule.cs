using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OasX.Membership;

namespace OasX.Integration
{
    public class MembershipModule : Module
    {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<OasXUserStore>().As<IUserStore<OasXIdentityUser>>().InstancePerRequest();
            builder.RegisterType<OasXRoleStore>().As<IRoleStore<IdentityRole, string>>().InstancePerRequest();

            builder.RegisterType<OasXUserManager>().InstancePerRequest();
            builder.RegisterType<OasXRoleManager>().InstancePerRequest();
        }
    }
}