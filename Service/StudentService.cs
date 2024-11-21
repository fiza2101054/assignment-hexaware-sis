using sis.Model;
using sis.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis.Service
{

        internal class StudentService : IStudentService
        {
        private readonly IStudentRepository _studentRepository;
        private readonly List<Payment> _paymentHistory;
        private readonly Dictionary<int, List<Course>> _studentCourses;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            _paymentHistory = new List<Payment>();
            _studentCourses = new Dictionary<int, List<Course>>(); // To track enrolled courses by student ID
        }

        public void EnrollInCourse(int studentId, Course course)
        {
            var student = _studentRepository.GetStudentById(studentId);
            if (student != null)
            {
                if (!_studentCourses.ContainsKey(studentId))
                {
                    _studentCourses[studentId] = new List<Course>();
                }
                _studentCourses[studentId].Add(course);
                Console.WriteLine($"Student {student.FirstName} {student.LastName} enrolled in {course.Coursename}.");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        public void UpdateStudentInfo(int studentId, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            var student = _studentRepository.GetStudentById(studentId);
            if (student != null)
            {
                student.FirstName = firstName;
                student.LastName = lastName;
                student.DateOfBirth = dateOfBirth;
                student.Email = email;
                student.PhoneNumber = phoneNumber;
                Console.WriteLine("Student information updated.");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        public void MakePayment(int studentId, decimal amount, DateTime paymentDate)
        {
            var student = _studentRepository.GetStudentById(studentId);
            if (student != null)
            {
                var payment = new Payment(_paymentHistory.Count + 1, studentId, (double)amount, paymentDate);
                _paymentHistory.Add(payment);
                Console.WriteLine($"Payment of {amount} made by {student.FirstName} {student.LastName} on {paymentDate.ToShortDateString()}.");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        public void DisplayStudentInfo(int studentId)
        {
            var student = _studentRepository.GetStudentById(studentId);
            if (student != null)
            {
                Console.WriteLine(student.ToString());
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        public List<Course> GetEnrolledCourses(int studentId)
        {
            if (_studentCourses.ContainsKey(studentId))
            {
                return _studentCourses[studentId];
            }
            return new List<Course>(); // Return empty list if no courses found
        }

        public List<Payment> GetPaymentHistory(int studentId)
        {
            return _paymentHistory.Where(p => p.StudentId == studentId).ToList();
        }

    }
    }

