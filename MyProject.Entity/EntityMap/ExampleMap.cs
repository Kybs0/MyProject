using MyProject.Entity.Entity;

namespace MyProject.Entity.EntityMap
{
    public class ExampleMap : EntityMap<Example>
    {
        public ExampleMap()
        {
            Property(i => i.Value).HasColumnName("ExampleVlue").HasPrecision(6, 2);
            Property(i => i.Remark).HasMaxLength(100);
        }
    }
}
