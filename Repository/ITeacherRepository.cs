using sis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis.Repository
{
    internal interface ITeacherRepository
    {
        List<Teacher> GetAllTeachers();
        List<Course> GetAssignedCoursesforTeacher(int teacherId);

        bool UpdateTeacherInfo(Teacher teacher);
        bool DoesTeacherExist(int teacherId);
    }
}
