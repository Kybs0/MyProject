using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using MyProject.Entity;

namespace MyProject.DAL
{
    public class EFDataContext
    {
        public static DbContext GetCurrentDbContext()
        {
            var dbContext = CallContext.GetData("DbContext") as DbContext;
            if (dbContext == null) //线程在数据槽里面没有此上下文
            {
                dbContext = new MyProjectDbContext();//创建一个EF上下文
                CallContext.SetData("DbContext", dbContext);
                dbContext.SaveChanges();
            }
            dbContext.Configuration.AutoDetectChangesEnabled = false;
            dbContext.Configuration.ValidateOnSaveEnabled = false;
            return dbContext;
        }
    }
}
