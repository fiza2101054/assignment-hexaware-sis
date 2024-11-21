using sis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis.Repository
{
    internal class StudentRepository : IStudentRepository
    {

        private List<Student> _students = new List<Student>();

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public Student GetStudentById(int studentId)
        {
            return _students.Find(s => s.StudentId == studentId);
        }

        public List<Student> GetAllStudents()
        {
            return _students;
        }
    }

 }
