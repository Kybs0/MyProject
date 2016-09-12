using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DAL.Excetpion
{
    public class EntityNotFoundException : BusinessException
    {
        public EntityNotFoundException()
            : base("The specified entity is not existed.")
        {

        }

        public EntityNotFoundException(string message)
            : base(message)
        {

        }
    }
}
