using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis.Exceptions
{
    internal class InvalidTeacherDataException : ApplicationException
    {
        public InvalidTeacherDataException()
        {
            
        }
        public InvalidTeacherDataException(String message) : base(message) 
        {
            
        }
    }
}
