using System;

namespace MyProject.Entity.Entity
{
    public abstract class EntityBase
    {        
        public int Id { get; set; }
    }

    public abstract class Entity : EntityBase
    {
        public DateTime CreateTime { get; set; }
        public int Creator { get; set; }
        public DateTime UpateTime { get; set; }
        public int Updator { get; set; }
    }

}
