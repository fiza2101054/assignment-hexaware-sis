using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis.Model
{
    internal class Enrollment
    {
        public int EnrollmentId{get; set; }
        public int StudentId
        {get; set;} // Reference to a Student
        
        public int CourseId
        {get; set;}  // Reference to a Course
        public DateTime EnrollmentDate { get; set; }

        // Constructor
        public Enrollment(int enrollmentId, int studentId, int courseId, DateTime enrollmentDate)
        {
            EnrollmentId = enrollmentId;
            StudentId = studentId;
            CourseId = courseId;
            EnrollmentDate = enrollmentDate;
        }

    }
}
