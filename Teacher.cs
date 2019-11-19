﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hogwarts.Models
{
    class Teacher
    {
        public Teacher(string firstName, string lastName, string socialSecurityNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
        }

        public int Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string SocialSecurityNumber { get; protected set; }
        public List<Course> Course { get; protected set; } = new List<Course>();
    }
}
