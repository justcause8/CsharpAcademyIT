using System;
using CsharpAcademyIT.Lab3;

namespace CsharpAcademyIT.Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppContext1())
            {
                var student = new Student
                {
                    FirstName = "Петр",
                    LastName = "Петров",
                    Age = 22,
                    Address = "Иркутск"
                };

                context.Students.Add(student);
                context.SaveChanges();

                Console.WriteLine("Студент успешно добавлен в базу данных.");
            }

            using (var context = new AppContext1())
            {
                var students = context.Students.ToList();

                Console.WriteLine("Список студентов:");
                foreach (var s in students)
                {
                    Console.WriteLine($"ID: {s.StudentId}, Имя: {s.FirstName}, Фамилия: {s.LastName}, Возраст: {s.Age}, Адрес: {s.Address}");
                }
            }
        }
    }
}