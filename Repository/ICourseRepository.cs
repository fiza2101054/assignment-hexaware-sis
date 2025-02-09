﻿using sis.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis.Repository
{
    internal interface ICourseRepository
    {
        bool AssignTeacherToCourse(int courseId, int teacherId);
        bool UpdateCourseInfo(int courseId, string courseName, int credits, int teacherId);

        Course GetCourseById(int courseId);

        Teacher GetTeacherForCourse(int courseId);

        (int enrollmentCount, double totalPayments) GetCourseStatistics(int courseId);

    }
}
