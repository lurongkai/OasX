using Microsoft.AspNet.Identity.EntityFramework;

namespace OasX.Membership
{
    public class OasXUserStore : UserStore<OasXIdentityUser>
    {
        public OasXUserStore(OasXIdentityDbContext context) : base(context) {}
    }
}