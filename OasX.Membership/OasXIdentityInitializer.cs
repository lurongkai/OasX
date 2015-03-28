using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OasX.Membership
{
    public class OasXIdentityInitializer : DropCreateDatabaseIfModelChanges<OasXIdentityDbContext>
    {
        protected override void Seed(OasXIdentityDbContext context) {
            var roleManager = new OasXRoleManager(new RoleStore<IdentityRole>(context));
            var userManager = new OasXUserManager(new UserStore<OasXIdentityUser>(context));

            roleManager.Create(new IdentityRole("Admin"));
            roleManager.Create(new IdentityRole("Teacher"));
            roleManager.Create(new IdentityRole("Student"));

            var passwordValidatorBackup = userManager.PasswordValidator;
            userManager.PasswordValidator = new MinimumLengthValidator(5);
            var admin = new OasXIdentityUser("admin");
            userManager.Create(admin, "admin");
            userManager.AddToRole(admin.Id, "Admin");
            userManager.PasswordValidator = passwordValidatorBackup;


            context.SaveChanges();
        }
    }
}