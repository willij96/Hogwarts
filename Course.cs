using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hogwarts.Models
{
    class Course
    {
        public Course(string title, string description, string points)
        {
            Title = title;
            Description = description;
            Points = points;
        }

        public Course(string title, string description, string points, Teacher teacher)
        {
            Title = title;
            Description = description;
            Points = points;
            Teacher = teacher;
        }

        public Course(string title)
        {
            Title = title;
        }

        public int Id { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public string Points { get; protected set; }

        public int TeacherId { get; set; }

        [ForeignKey(nameof(TeacherId)),Required ]
        public Teacher Teacher { get; protected set; }
        public List<StudentCourse> StudentCourse { get; protected set; } = new List<StudentCourse>();

    }
}
