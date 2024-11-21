using sis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis.Repository
{
    internal interface IStudentRepository
    {
        void AddStudent(Student student);
        Student GetStudentById(int studentId);
        List<Student> GetAllStudents();
    }
}
