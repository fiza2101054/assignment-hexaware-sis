using sis.Model;
using sis.Repository;
using sis.Service;
using System;

namespace sis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studentRepo = new StudentRepository();
            var studentService = new StudentService(studentRepo);

            // Sample student and courses for testing
            var student1 = new Student(1, "Fiza", "S", new DateTime(2003, 6, 1), "fiza@gmail.com", "123-456-7890");
            var student2 = new Student(2, "Rahul", "Dharma", new DateTime(2003, 10, 2), "rahul@gmail.com", "321-654-9870");
            studentRepo.AddStudent(student1);
            studentRepo.AddStudent(student2);

            var course1 = new Course(1, "Math 101", "MTH101", "Vanishree");
            var course2 = new Course(2, "Science 101", "SCI101", "Vishnu Durai");

            // Menu for interactions
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Enroll in Course");
                Console.WriteLine("2. Update Student Info");
                Console.WriteLine("3. Make Payment");
                Console.WriteLine("4. Display Student Info");
                Console.WriteLine("5. Get Enrolled Courses");
                Console.WriteLine("6. Get Payment History");
                Console.WriteLine("7. Exit");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Student ID:");
                            int studentIdForEnrollment = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Course ID (1 for Math 101, 2 for Science 101):");
                            int courseId = int.Parse(Console.ReadLine());
                            Course selectedCourse = courseId == 1 ? course1 : course2;
                            studentService.EnrollInCourse(studentIdForEnrollment, selectedCourse);
                            Console.ReadLine(); // Ensure program doesn't go back to menu immediately
                            break;

                        case 2:
                            Console.WriteLine("Enter Student ID to update:");
                            int studentIdForUpdate = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter new First Name:");
                            string firstName = Console.ReadLine();
                            Console.WriteLine("Enter new Last Name:");
                            string lastName = Console.ReadLine();
                            Console.WriteLine("Enter new Date of Birth (yyyy-mm-dd):");
                            DateTime dob = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Enter new Email:");
                            string email = Console.ReadLine();
                            Console.WriteLine("Enter new Phone Number:");
                            string phone = Console.ReadLine();
                            studentService.UpdateStudentInfo(studentIdForUpdate, firstName, lastName, dob, email, phone);
                            Console.ReadLine(); // Ensure program doesn't go back to menu immediately
                            break;

                        case 3:
                            Console.WriteLine("Enter Student ID for payment:");
                            int studentIdForPayment = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Payment Amount:");
                            decimal amount = decimal.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Payment Date (yyyy-mm-dd):");
                            DateTime paymentDate = DateTime.Parse(Console.ReadLine());
                            studentService.MakePayment(studentIdForPayment, amount, paymentDate);
                            Console.ReadLine(); // Ensure program doesn't go back to menu immediately
                            break;

                        case 4:
                            Console.WriteLine("Enter Student ID to display:");
                            int studentIdForInfo = int.Parse(Console.ReadLine());
                            studentService.DisplayStudentInfo(studentIdForInfo);
                            Console.ReadLine(); // Ensure program doesn't go back to menu immediately
                            break;

                        case 5:
                            Console.WriteLine("Enter Student ID to get enrolled courses:");
                            int studentIdForCourses = int.Parse(Console.ReadLine());
                            var courses = studentService.GetEnrolledCourses(studentIdForCourses);
                            if (courses.Count == 0)
                                Console.WriteLine("No courses found for this student.");
                            else
                                courses.ForEach(course => Console.WriteLine(course.Coursename));
                            Console.ReadLine(); // Ensure program doesn't go back to menu immediately
                            break;

                        case 6:
                            Console.WriteLine("Enter Student ID to get payment history:");
                            int studentIdForPayments = int.Parse(Console.ReadLine());
                            var payments = studentService.GetPaymentHistory(studentIdForPayments);
                            if (payments.Count == 0)
                                Console.WriteLine("No payment history for this student.");
                            else
                                payments.ForEach(p => Console.WriteLine($"Payment ID: {p.PaymentId}, Amount: {p.Amount}, Date: {p.PaymentDate.ToShortDateString()}"));
                            Console.ReadLine(); // Ensure program doesn't go back to menu immediately
                            break;

                        case 7:
                            exit = true; // Exit the loop and end the program
                            break;

                        default:
                            Console.WriteLine("Invalid choice, try again.");
                            Console.ReadLine(); // Pause before going back to menu
                            break;
                    }

                }
            }

        }
    }
}
