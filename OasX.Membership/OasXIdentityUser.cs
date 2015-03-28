using Microsoft.AspNet.Identity.EntityFramework;

namespace OasX.Membership
{
    public class OasXIdentityUser : IdentityUser
    {
        public OasXIdentityUser() {}
        public OasXIdentityUser(string userName) : base(userName) {}

        public Gender Gender { get; set; }
    }
}