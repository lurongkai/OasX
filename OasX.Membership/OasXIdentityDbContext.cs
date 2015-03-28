using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OasX.Membership
{
    public class OasXIdentityDbContext : IdentityDbContext<OasXIdentityUser>
    {
        public OasXIdentityDbContext() : base("OasX.Membership") {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            Database.SetInitializer(new OasXIdentityInitializer());
            base.OnModelCreating(modelBuilder);
        }
    }
}