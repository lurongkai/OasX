using System.Data.Entity.ModelConfiguration;
using OasX.Domain;

namespace OasX.Infrastructure.Mapping
{
    public class SubjectMapping : EntityTypeConfiguration<Subject>
    {
        public SubjectMapping() {
            HasKey(m => m.SubjectId);
            Property(m => m.Name).IsRequired();

            HasRequired(m => m.BelongTo);
        }
    }
}