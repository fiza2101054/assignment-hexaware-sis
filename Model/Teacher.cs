﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sis.Model
{
    internal class Teacher
    {
        public int TeacherId{get; set;}
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public string Email{get; set;}

       
        public Teacher(int teacherId, string firstName, string lastName, string email)
        {
            TeacherId = teacherId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        public override string ToString()
        {
            return $"Teacher ID: {TeacherId}\n" +
                   $"Name: {FirstName} {LastName}\n" +
                   $"Email: {Email}";
        }

    }
}
