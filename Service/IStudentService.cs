using sis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis.Service
{
    internal interface IStudentService
    {
        void EnrollInCourse(int studentId, Course course);
        void UpdateStudentInfo(int studentId, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber);
        void MakePayment(int studentId, decimal amount, DateTime paymentDate);
        void DisplayStudentInfo(int studentId);
        List<Course> GetEnrolledCourses(int studentId);
        List<Payment> GetPaymentHistory(int studentId);
    }
}
