using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static List<Course> GetUniqueCourses(List<Student> students)
    {
        return students
            .SelectMany(s => s.Courses)
            .GroupBy(c => c.Name)
            .Select(g => g.First())
            .ToList();
    }

    public static List<Student> GetTopStudents(List<Student> students)
    {
        return students
            .OrderByDescending(s => s.Courses.Count)
            .Take(3)
            .ToList();
    }

    public static List<Student> GetStudentsByCourse(List<Student> students, Course course)
    {
        return students
            .Where(s => s.Courses
            .Any(c => c.Name == course.Name))
            .ToList();
    }

    public static void Main()
    {
 
        var students = new List<Student>
        {
            new Student {Name = "Илон Маск", Courses = new List<Course> {new Course {Name = "Математика"}, new Course {Name = "Физика"}, new Course {Name = "Программирование"}, new Course {Name = "История"}}},
            new Student {Name = "Боб Росс", Courses = new List<Course> {new Course {Name = "Рисование"}, new Course {Name = "История"}, new Course {Name = "Биология"}}},
            new Student {Name = "Хидео Кодзима", Courses = new List<Course> {new Course {Name = "Физика"}, new Course {Name = "Программирование"}}},
            new Student {Name = "Сергей Брин", Courses = new List<Course> {new Course {Name = "Программирование"}}}
        };

        Console.WriteLine("Список студентов и их курсов: \n");

        foreach (var student in students)
        {
            Console.WriteLine($"Студент: {student.Name}");
            Console.WriteLine("Курсы:");
            foreach (var course in student.Courses)
            {
                Console.WriteLine($"- {course.Name}");
            }
            Console.WriteLine();
        }

        var uniqueCourses = GetUniqueCourses(students);
        Console.WriteLine("Уникальные курсы: ");
        foreach (var course in uniqueCourses)
        {
            Console.WriteLine($"- {course.Name}");
        }
        Console.WriteLine();

        var topStudents = GetTopStudents(students);
        Console.WriteLine("Топ 3 студентов с наибольшим количеством курсов: ");
        foreach (var student in topStudents)
        {
            Console.WriteLine($"- {student.Name}");
        }
        Console.WriteLine();

        var studentsByCourse = GetStudentsByCourse(students, new Course { Name = "Программирование" });
        Console.WriteLine("Студенты, у которых преподается программирование: ");
        foreach (var student in studentsByCourse)
        {
            Console.WriteLine($"- {student.Name}");
        }
    }
}