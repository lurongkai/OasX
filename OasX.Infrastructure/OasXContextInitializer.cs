using System.Data.Entity;

namespace OasX.Infrastructure
{
    public class OasXContextInitializer : DropCreateDatabaseIfModelChanges<OasXContext>
    {
        protected override void Seed(OasXContext context) {
            // context.SaveChanges();
        }
    }
}