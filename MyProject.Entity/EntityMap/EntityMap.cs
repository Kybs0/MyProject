using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MyProject.Entity.EntityMap
{
    public class EntityMap<T> : EntityTypeConfiguration<T> where T : Entity.Entity
    {
        public EntityMap()
        {
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
