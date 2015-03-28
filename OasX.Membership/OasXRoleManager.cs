using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OasX.Membership
{
    public class OasXRoleManager : RoleManager<IdentityRole>
    {
        public OasXRoleManager(IRoleStore<IdentityRole, string> store) : base(store) {}
    }
}