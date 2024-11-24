using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis.Exceptions
{
    internal class InvalidStudentDataException : ApplicationException
    {

        public InvalidStudentDataException()
        {
            
        }
        public InvalidStudentDataException(String message) : base(message) 
         {
            
        }
    }
}
