using Microsoft.AspNet.Identity.EntityFramework;

namespace OasX.Membership
{
    public class OasXRoleStore : RoleStore<IdentityRole>
    {
        public OasXRoleStore(OasXIdentityDbContext context) : base(context) {}
    }
}