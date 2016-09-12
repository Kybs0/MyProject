using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.DAL.Excetpion;
using MyProject.DAL.IService;
using MyProject.Entity.Entity;

namespace MyProject.DAL.Service
{
    public class ExampleService : BaseDAL<Example>, IExampleService
    {
        public List<Example> GetAllExamples()
        {
            var result = this.AsQueryable();
            if (result == null || !result.Any())
            {
                return new List<Example>();
            }
            return result.ToList();
        }

        public Example GetExample(int id)
        {
            Example example = this.GetById(id);
            if (example == null)
            {
                throw new EntityNotFoundException();
            }

            return example;
        }

        public int Create(Example example)
        {
            using (this.BeginTransaction())
            {
                try
                {
                    this.Insert(example);

                    this.SaveChanges();
                    this.Commit();
                }
                catch
                {
                    this.Rollback();
                    throw;
                }
            }
            return example.Id;
        }

        public void Update(Example example)
        {
            if (this.Any(i => i.Id == example.Id))
            {
                throw new EntityNotFoundException();
            }
            //更新
            using (this.BeginTransaction())
            {
                try
                {
                    this.Update(example);

                    this.SaveChanges();
                    this.Commit();
                }
                catch
                {
                    this.Rollback();
                    throw;
                }
            }
        }

        public void Delete(int id)
        {
            using (this.BeginTransaction())
            {
                try
                {
                    var template = GetExample(id);
                    this.Delete(template);

                    this.SaveChanges();
                    this.Commit();
                }
                catch
                {
                    this.Rollback();
                    throw;
                }
            }
        }

        public void DeleteBulk(List<int> idList)
        {
            var queryResult = this.AsQueryable(i => idList.Any(id => id == i.Id));
            if (queryResult == null || queryResult.Count() != idList.Count)
            {
                throw new EntityNotFoundException();
            }
            //批量删除
            using (this.BeginTransaction())
            {
                try
                {
                    foreach (var templateId in idList)
                    {
                        var template = GetExample(templateId);
                        this.Delete(template);
                    }
                    this.SaveChanges();
                    this.Commit();
                }
                catch
                {
                    this.Rollback();
                    throw;
                }
            }
        }
    }
}
