﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis.Exceptions
{
    internal class TeacherNotFoundException : ApplicationException
    {

        public TeacherNotFoundException()
        {
            
        }
        public TeacherNotFoundException( String message) : base(message) 
        {
            
        }
    }
}
