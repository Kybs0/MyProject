using System.Data.Entity;
using log4net;
using MyProject.Entity.Entity;
using MyProject.Entity.EntityMap;

namespace MyProject.Entity
{
    public class MyProjectDbContext : DbContext
    {
        ////日志
        private static readonly ILog Logger = LogManager.GetLogger(typeof (MyProjectDbContext));
        //初始化
        public MyProjectDbContext()
            : base(AppSetting.Instance.GetValue("ICSDbContext"))
        {
            Database.SetInitializer<MyProjectDbContext>(null);
            //Database.Log = Logger.Debug;
        }

        public DbSet<Example> Examples { get; set; }

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Example>().Property(i => i.Name).HasColumnName("ExampleName");
            //modelBuilder.Configurations.Add(new ExampleMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
