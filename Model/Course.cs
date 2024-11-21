using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis.Model
{
    internal class Course
    {
        public int CourseId {get; set;}
        public string Coursename {get; set;}
        public string Coursecode {get; set;}
        public string Instructorname {get; set;}

        // creating constructor
        public Course(int courseId, string courseName, string courseCode, string instructorName)
        {
            CourseId = courseId;
            Coursename = courseName;
            Coursecode = courseCode;
            Instructorname = instructorName;
        }
    }
}
