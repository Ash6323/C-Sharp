using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeProject
{
    internal class LINQDemo
    {
        internal void LINQ()
        {
            List<int> integerList = new()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };
            // QUERY SYNTAX
            //IEnumerable<int> querySyntax = from obj in integerList where obj > 5 select obj;

            //METHOD SYNTAX
            List<int> methodSyntax = integerList.Where(obj => obj > 5).ToList();

            foreach (int item in methodSyntax)
                Console.Write(item + " ");

            Console.WriteLine();

            //MIXED SYNTAX
            int mixedSyntax = (from obj in integerList where obj > 5 select obj).Sum();
            Console.Write("Sum Is : " + mixedSyntax);

            Console.WriteLine();

            List<Student> studentList = new()
            {
                new Student(){ID = 1, Name = "Ashwin", Gender = "Male"},
                new Student(){ID = 2, Name = "Piyush", Gender = "Male"},
                new Student(){ID = 3, Name = "Preeti", Gender = "Female"},
                new Student(){ID = 4, Name = "Omkar", Gender = "Male"},
                new Student(){ID = 5, Name = "Karishma", Gender = "Female"},
                new Student(){ID = 6, Name = "Anand", Gender = "Male"}
            };

            var query = studentList.Where(obj => obj.Gender == "Male").
                Select(stu => new { ID = stu.ID, Name = stu.Name }).ToList();
            foreach (var student in query)
            {
                //Console.WriteLine($"ID : {student.ID}  Name : {student.Name}");
                Console.WriteLine($"{student.ID} {student.Name}");
            }
        }
    }
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
    }
}

