using Hogwarts.Data;
using Hogwarts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static System.Console;

namespace Hogwarts
{
    class Program
    {
        static HogwartsContext context = new HogwartsContext();
        static void Main(string[] args)
        {            

            bool shouldNotExit = true;

            while (shouldNotExit)
            {
                WriteLine("1. Registrera elev");
                WriteLine("2. Lista elever");
                WriteLine("3. Lägg till lärare");
                WriteLine("4. Lägg till kurs");
                WriteLine("5. Lägg till elev till kurs");
                WriteLine("6. Lista kurser");
                WriteLine("7. Exit");

                ConsoleKeyInfo keyPressed = ReadKey(true);

                Clear();

                switch (keyPressed.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        RegisterStudent();

                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:

                        ListStudent();

                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:

                        AddTeacher();

                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:

                        AddCourse();

                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:

                        AddStudentToCourse();

                        break;

                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:

                        ListCourse();

                        break;

                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:

                        shouldNotExit = false;

                        break;
                }

                Clear();
            }

        }

        private static void AddStudentToCourse()
        {

            bool isCorrect = false;
            do
            {
                Write("Elev (personnr): ");
                string socialSecurityNumber = ReadLine();

                Write("Kurs (titel): ");
                string title = ReadLine();

                WriteLine();

                WriteLine("Är detta korrekt? (J)a eller (N)ej");

                ConsoleKeyInfo keyPressed;

                bool isValidKey = false;

                do
                {
                    keyPressed = ReadKey(true);

                    isValidKey = keyPressed.Key == ConsoleKey.J ||
                                 keyPressed.Key == ConsoleKey.N;

                } while (!isValidKey);

                if (keyPressed.Key == ConsoleKey.J)
                {
                    Clear();

                    Student student = context.Student
                        .FirstOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber);
                    Course course = context.Course
                        .FirstOrDefault(x => x.Title == title);

                    if (student == null)
                    {
                        WriteLine("hittades ej");
                    }
                    else if (course == null)
                    {
                        WriteLine(" hittades inte");
                    }
                    else
                    {
                        StudentCourse studentCourse = new StudentCourse(student.Id);

                        course.StudentCourse.Add(studentCourse);

                        context.SaveChanges();

                        WriteLine("student lades till kurs");
                    }
                    Thread.Sleep(2000);

                    

                    isCorrect = true;
                }

                Clear();

            } while (!isCorrect);

        }

        private static void ListCourse()
        {
            List<Course> listCourses = context.Course
                .Include(x => x.Teacher)
                .Include(x => x.StudentCourse)
                .ThenInclude(x => x.Student)
                .ThenInclude(x => x.Address).ToList();

            foreach (var course in listCourses)
            {
                WriteLine($"Titel: {course.Title}");
                WriteLine($"Beskrivning: {course.Description}");
                WriteLine($"Poäng: {course.Points}");
                WriteLine($"Lärare: {course.Teacher.FirstName} {course.Teacher.LastName}");

                WriteLine("Elever:");

                foreach (var collectionOfCourses in course.StudentCourse)
                {
                    WriteLine($"\t{collectionOfCourses.Student.FirstName} {collectionOfCourses.Student.LastName}");
                }
                WriteLine("----------------------------------------------------------------------------------");
            }
            ReadKey(true);
        }

        private static void RegisterStudent()
        {

            bool isCorrect = false;
            do
            {
                Write("Förnamn: ");
                string firstName = ReadLine();

                Write("Efternamn: ");
                string lastName = ReadLine();

                Write("Personnummer: ");
                string socialSecurityNumber = ReadLine();

                Write("Gata: ");
                string street = ReadLine();

                Write("Stad: ");
                string city = ReadLine();

                Write("Postnummer: ");
                string postCode = ReadLine();

                WriteLine();

                WriteLine("Är detta korrekt? (J)a eller (N)ej");

                ConsoleKeyInfo keyPressed;

                bool isValidKey = false;

                do
                {
                    keyPressed = ReadKey(true);

                    isValidKey = keyPressed.Key == ConsoleKey.J ||
                                 keyPressed.Key == ConsoleKey.N;

                } while (!isValidKey);

                if (keyPressed.Key == ConsoleKey.J)
                {
                    Clear();

                    Student student1 = context.Student
                        .FirstOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber);

                    if (student1 != null)
                    {
                        WriteLine("Elev redan registrerad");

                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Address address = new Address(street, city, postCode);

                        Student student = new Student(firstName, lastName, socialSecurityNumber, address);

                        context.Student.Add(student);

                        context.SaveChanges();

                        WriteLine("Elev registrerad");

                        Thread.Sleep(2000); // 2 sec
                    }

                    isCorrect = true;
                }

                Clear();

            } while (!isCorrect);

        }

        private static void ListStudent()
        {

            List<Student> studentList = context.Student
        .Include(x => x.Address)
        .ToList();

            Write("Namn".PadRight(25, ' '));
            WriteLine("Adress");
            WriteLine("-----------------------------------------------");

            foreach (Student student in studentList)
            {
                Address address = student.Address;

                Write($"{student.FirstName} {student.LastName}, {student.SocialSecurityNumber}       " +
                    $"{address.Street}, {address.PostCode} {address.City}");
            }

            ReadKey(true);

        }

        private static void AddTeacher()
        {

            bool isCorrect = false;
            do
            {
                Write("Förnamn: ");
                string firstName = ReadLine();

                Write("Efternamn: ");
                string lastName = ReadLine();

                Write("Personnummer: ");
                string socialSecurityNumber = ReadLine();

                WriteLine();

                WriteLine("Är detta korrekt? (J)a eller (N)ej");

                ConsoleKeyInfo keyPressed;

                bool isValidKey = false;

                do
                {
                    keyPressed = ReadKey(true);

                    isValidKey = keyPressed.Key == ConsoleKey.J ||
                                 keyPressed.Key == ConsoleKey.N;

                } while (!isValidKey);

                if (keyPressed.Key == ConsoleKey.J)
                {
                    Clear();

                    Teacher teacher1 = context.Teacher
                        .FirstOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber);

                    if (teacher1 != null)
                    {
                        WriteLine("lärare redan tillagd");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Teacher teacher = new Teacher(firstName, lastName, socialSecurityNumber);

                        context.Add(teacher);

                        context.SaveChanges();

                        WriteLine("Lärare tillagd");

                        Thread.Sleep(2000); // 2 sec
                    }

                    

                    isCorrect = true;
                }

                Clear();

            } while (!isCorrect);

        }

        private static void AddCourse()
        {

            bool isCorrect = false;
            do
            {
                Write("Titel: ");
                string title = ReadLine();

                Write("Beskrivning: ");
                string description = ReadLine();

                Write("Poäng: ");
                string points = ReadLine();

                Write("Lärare (personnr): ");
                string socialSecurityNumber = ReadLine();

                WriteLine();

                WriteLine("Är detta korrekt? (J)a eller (N)ej");

                ConsoleKeyInfo keyPressed;

                bool isValidKey = false;

                do
                {
                    keyPressed = ReadKey(true);

                    isValidKey = keyPressed.Key == ConsoleKey.J ||
                                 keyPressed.Key == ConsoleKey.N;

                } while (!isValidKey);

                if (keyPressed.Key == ConsoleKey.J)
                {
                    Clear();

                    Teacher teacher = context.Teacher
                        .FirstOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber);

                    if (teacher != null)
                    {
                        if (context.Course.Any(x => x.Title == title))
                        {
                            WriteLine("Kurs redan tillagd");
                        }
                        else
                        {
                            Course course = new Course(title, description, points);

                            teacher.Course.Add(course);

                            context.SaveChanges();

                            WriteLine("Kurs tillagd");

                            Thread.Sleep(2000); // 2 sec
                        }
                    }
                    else
                    {
                        WriteLine("Ogiltig lärare");                        
                    }
                    Thread.Sleep(2000);

                    

                    isCorrect = true;
                }

                Clear();

            } while (!isCorrect);

        }
    }
}
