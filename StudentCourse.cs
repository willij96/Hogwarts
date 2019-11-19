using System;
using System.Collections.Generic;
using System.Text;

namespace Hogwarts.Models
{
    class StudentCourse
    {
        public int StudentId { get; protected set; }
        public int CourseId { get; protected set; }
        public Student Student { get; protected set; }
        public Course Course { get; protected set; }

        public StudentCourse()
        {

        }
        public StudentCourse(int studentId)
        {
            StudentId = studentId;
        }
    }
}
