using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Entity.Entity;

namespace MyProject.DAL.IService
{
    public interface IExampleService
    {
        List<Example> GetAllExamples();

        Example GetExample(int id);

        int Create(Example example);

        void Update(Example example);

        void Delete(int id);

        void DeleteBulk(List<int> idList);
    }
}
