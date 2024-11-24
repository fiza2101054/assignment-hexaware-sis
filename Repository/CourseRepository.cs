using sis.Model;
using sis.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis.Repository
{
    internal class CourseRepository : ICourseRepository
    {
       
            private readonly string _connectionString;
            private SqlCommand _cmd;

            public CourseRepository()
            {
                _connectionString = DBConnUtil.GetConnectionString();
                _cmd = new SqlCommand();
            }

            public bool AssignTeacherToCourse(int courseId, int teacherId)
        {
            bool isAssigned = false;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = @"
                    UPDATE Courses
                    SET teacher_id = @TeacherId
                    WHERE course_id = @CourseId";

                    _cmd.CommandText = query;
                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@CourseId", courseId);
                    _cmd.Parameters.AddWithValue("@TeacherId", teacherId);
                    _cmd.Connection = conn;

                    conn.Open();
                    int rowsAffected = _cmd.ExecuteNonQuery();
                    isAssigned = rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error assigning teacher to course: {ex.Message}");
                }
            }

            return isAssigned;
        }

        public bool UpdateCourseInfo(int courseId, string courseName, int credits, int teacherId)
        {
            bool isUpdated = false;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = @"
                        UPDATE Courses
                        SET 
                            course_name = @CourseName,
                            credits = @Credits,
                            teacher_id = @TeacherId
                        WHERE course_id = @CourseId";

                    _cmd.CommandText = query;
                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@CourseId", courseId);
                    _cmd.Parameters.AddWithValue("@CourseName", courseName);
                    _cmd.Parameters.AddWithValue("@Credits", credits);
                    _cmd.Parameters.AddWithValue("@TeacherId", teacherId);

                    _cmd.Connection = conn;
                    conn.Open();

                    int rowsAffected = _cmd.ExecuteNonQuery();
                    isUpdated = rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating course: {ex.Message}");
                }
            }

            return isUpdated;
        }

        public Course GetCourseById(int courseId)
        {
            Course course = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = @"
                        SELECT course_id, course_name, credits, teacher_id
                        FROM Courses
                        WHERE course_id = @CourseId";

                    _cmd.CommandText = query;
                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@CourseId", courseId);

                    _cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = _cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            course = new Course(
                                Convert.ToInt32(reader["course_id"]),
                                reader["course_name"].ToString(),
                                Convert.ToInt32(reader["credits"]),
                                Convert.ToInt32(reader["teacher_id"])
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching course information: {ex.Message}");
                }
            }

            return course;
        }


        public Teacher GetTeacherForCourse(int courseId)
        {
            Teacher teacher = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = @"
            SELECT t.teacher_id, t.first_name, t.last_name, t.email
            FROM Courses c
            INNER JOIN Teacher t ON c.teacher_id = t.teacher_id
            WHERE c.course_id = @CourseId";

                    _cmd.CommandText = query;
                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@CourseId", courseId);
                    _cmd.Connection = conn;

                    conn.Open();

                    using (SqlDataReader reader = _cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            teacher = new Teacher(
                                Convert.ToInt32(reader["teacher_id"]),
                                reader["first_name"].ToString(),
                                reader["last_name"].ToString(),
                                reader["email"].ToString()
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching teacher for course ID {courseId}: {ex.Message}");
                }
            }

            return teacher;
        }

        public (int enrollmentCount, double totalPayments) GetCourseStatistics(int courseId)
        {
            int enrollmentCount = 0;
            double totalPayments = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = @"
                            SELECT COUNT(*) AS EnrollmentCount, 
                                   SUM(p.amount) AS TotalPayments
                            FROM Enrollments e
                            LEFT JOIN Payments p ON e.student_id = p.student_id
                            WHERE e.course_id = @CourseId";

                    _cmd.CommandText = query;
                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@CourseId", courseId);
                    _cmd.Connection = conn;

                    conn.Open();

                    using (SqlDataReader reader = _cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            enrollmentCount = reader["EnrollmentCount"] != DBNull.Value ? Convert.ToInt32(reader["EnrollmentCount"]) : 0;
                            totalPayments = reader["TotalPayments"] != DBNull.Value ? Convert.ToDouble(reader["TotalPayments"]) : 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching course statistics: {ex.Message}");
                }
            }

            return (enrollmentCount, totalPayments);
        }

    }
}
