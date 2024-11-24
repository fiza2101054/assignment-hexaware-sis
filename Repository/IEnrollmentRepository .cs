using sis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis.Repository
{
    internal interface IEnrollmentRepository
    {
        List<Course> GetEnrolledCourses(int studentId);
         bool  EnrollInCourse(int studentId, int courseId);

        List<Student> GetEnrollments(int courseId);

        Student GetStudent(int enrollmentId);

        Course GetCourse(int enrollmentId);
    }
}
