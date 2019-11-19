using System;
using System.Collections.Generic;
using System.Text;

namespace Hogwarts.Models
{
    class Student
    {
        public Student(string firstName, string lastName, string socialSecurityNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
        }

        public Student(string firstName, string lastName, string socialSecurityNumber, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
            Address = address;
        }
        public Student(string socialSecurityNumber, Course course)
        {
            SocialSecurityNumber = socialSecurityNumber;
            Course = course;
        }

        public int Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string SocialSecurityNumber { get; protected set; }
        public Address Address { get; protected set; }
        public Course Course { get; protected set; }
        public List<StudentCourse> StudentCourse { get; protected set; } = new List<StudentCourse>();
    }
}
