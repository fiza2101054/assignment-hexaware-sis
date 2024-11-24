using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis.Model
{
    internal class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }  
        public int TeacherId { get; set; }  

      
        public Course(int courseId, string courseName, int credits, int teacherId)
        {
            CourseId = courseId;
            CourseName = courseName;
            Credits = credits;
            TeacherId = teacherId;
        }

       
        public override string ToString()
        {
            return $"Course ID: {CourseId}\n" +
                   $"Course Name: {CourseName}\n" +
                   $"Credits: {Credits}\n" +
                   $"Teacher ID: {TeacherId}";
        }
    }
}
