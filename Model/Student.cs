using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis.Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

      
        public Student(int studentId, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
        }

       
        public override string ToString()
        {
            return $"ID: {StudentId}\n" +
                   $"Name: {FirstName} {LastName}\n" +
                   $"Date of Birth: {DateOfBirth}\n" +
                   $"Email: {Email}\n" +
                   $"Phone Number: {PhoneNumber}";
        }
    }
}
