using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis.Exceptions
{
    internal class InsufficientFundsException : ApplicationException
    {
        public InsufficientFundsException()
        {
            
        }
        public InsufficientFundsException( String message) : base(message) 
        {
            
        }
    }
}
