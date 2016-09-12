using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DAL.IService
{
    public interface IBaseDAL<T>
    {
        T GetById(int id);
        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        bool Any(Expression<Func<T, bool>> predicate);
    }
}
