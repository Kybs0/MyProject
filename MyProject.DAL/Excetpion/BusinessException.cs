using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DAL.Excetpion
{
    public class BusinessException : Exception
    {
        public BusinessExceptionType Type { get; set; }

        public BusinessException(string message, BusinessExceptionType type = BusinessExceptionType.Error)
            : base(message)
        {
            Type = type;
        }
    }

    public enum BusinessExceptionType
    {
        Info,
        Error,
        Warning
    }
}
