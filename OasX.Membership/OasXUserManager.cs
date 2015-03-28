using Microsoft.AspNet.Identity;

namespace OasX.Membership
{
    public class OasXUserManager : UserManager<OasXIdentityUser>
    {
        public OasXUserManager(IUserStore<OasXIdentityUser> store) : base(store) {}
    }
}