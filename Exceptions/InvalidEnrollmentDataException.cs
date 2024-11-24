using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis.Exceptions
{
    internal class InvalidEnrollmentDataException : ApplicationException
    {

        public InvalidEnrollmentDataException()
        {
            
        }
        public InvalidEnrollmentDataException(String message) : base(message) 
        {
            
        }
    }
}
