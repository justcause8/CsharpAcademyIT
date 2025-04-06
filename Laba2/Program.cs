using System;
using Laba2.Models;
using Microsoft.EntityFrameworkCore;

namespace Laba2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Просмотреть студентов");
                Console.WriteLine("2. Добавить студента");
                Console.WriteLine("3. Обновить студента");
                Console.WriteLine("4. Удалить студента");
                Console.WriteLine("5. Просмотреть курсы");
                Console.WriteLine("6. Добавить курс");
                Console.WriteLine("7. Обновить курс");
                Console.WriteLine("8. Удалить курс");
                Console.WriteLine("9. Просмотреть учителей");
                Console.WriteLine("10. Добавить учителя");
                Console.WriteLine("11. Обновить учителя");
                Console.WriteLine("12. Удалить учителя");
                Console.WriteLine("13. Ленивая загрузка");
                Console.WriteLine("q. Выход");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();

                using (AppContext db = new())
                {
                    switch (choice)
                    {
                        case "1": ReadStudents(db); break;
                        case "2": AddStudent(db); break;
                        case "3": UpdateStudent(db); break;
                        case "4": DeleteStudent(db); break;
                        case "5": ReadCourses(db); break;
                        case "6": AddCourse(db); break;
                        case "7": UpdateCourse(db); break;
                        case "8": DeleteCourse(db); break;
                        case "9": ReadTeachers(db); break;
                        case "10": AddTeacher(db); break;
                        case "11": UpdateTeachers(db); break;
                        case "12": DeleteTeacher(db); break;
                        case "13": LazyLoadingExample(db); break;
                        case "q": Console.WriteLine("Выход"); return;
                        default: Console.WriteLine("Неверный выбор!"); break;
                    }
                }
            }
        }

        // Методы для работы со студентами
        static void ReadStudents(AppContext db)
        {
            var students = db.Students.ToList();
            if (students.Count == 0)
            {
                Console.WriteLine("Список студентов пуст.");
                return;
            }

            Console.WriteLine("Список студентов:");
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.StudentId}, Имя: {student.FirstName}, Фамилия: {student.LastName}, Возраст: {student.Age}");
            }
        }

        static void AddStudent(AppContext db)
        {
            Console.Write("Введите имя: ");
            string firstName = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            string lastName = Console.ReadLine();
            Console.Write("Введите возраст: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Введите адрес: ");
            string adress = Console.ReadLine();

            var student = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Address = adress
            };

            db.Students.Add(student);
            db.SaveChanges();
            Console.WriteLine("Студент успешно добавлен.");
        }

        static void UpdateStudent(AppContext db)
        {
            Console.Write("Введите ID студента для обновления: ");
            int id = int.Parse(Console.ReadLine());
            var student = db.Students.Find(id);

            if (student == null)
            {
                Console.WriteLine("Студент не найден.");
                return;
            }

            Console.Write("Введите новое имя: ");
            string newFirstName = Console.ReadLine();
            Console.Write("Введите новую фамилию: ");
            string newLastName = Console.ReadLine();
            Console.Write("Введите новый возраст: ");
            int newAge = int.Parse(Console.ReadLine());
            Console.Write("Введите новый адрес: ");
            string newAdress = Console.ReadLine();

            student.FirstName = newFirstName;
            student.LastName = newLastName;
            student.Age = newAge;
            student.Address = newAdress;

            db.SaveChanges();
            Console.WriteLine("Студент успешно обновлен.");
        }

        static void DeleteStudent(AppContext db)
        {
            Console.Write("Введите ID студента для удаления: ");
            int id = int.Parse(Console.ReadLine());
            var student = db.Students.Find(id);

            if (student == null)
            {
                Console.WriteLine("Студент не найден.");
                return;
            }

            db.Students.Remove(student);
            db.SaveChanges();
            Console.WriteLine("Студент успешно удален.");
        }

        // Методы для работы с курсами
        static void ReadCourses(AppContext db)
        {
            var courses = db.Courses.ToList();
            if (courses.Count == 0)
            {
                Console.WriteLine("Список курсов пуст.");
                return;
            }

            Console.WriteLine("Список курсов:");
            foreach (var course in courses)
            {
                Console.WriteLine($"ID: {course.CourseId}, Название: {course.CourseName}");
            }
        }

        static void AddCourse(AppContext db)
        {
            Console.Write("Введите название курса: ");
            string courseName = Console.ReadLine();

            var course = new Course
            {
                CourseName = courseName
            };

            db.Courses.Add(course);
            db.SaveChanges();
            Console.WriteLine("Курс успешно добавлен.");
        }

        static void UpdateCourse(AppContext db)
        {
            Console.Write("Введите ID курса для обновления: ");
            int id = int.Parse(Console.ReadLine());
            var course = db.Courses.Find(id);

            if (course == null)
            {
                Console.WriteLine("Курс не найден.");
                return;
            }

            Console.Write("Введите новое название курса: ");
            string newCourseName = Console.ReadLine();

            course.CourseName = newCourseName;

            db.SaveChanges();
            Console.WriteLine("Курс успешно обновлен.");
        }

        static void DeleteCourse(AppContext db)
        {
            Console.Write("Введите ID курса для удаления: ");
            int id = int.Parse(Console.ReadLine());
            var course = db.Courses.Find(id);

            if (course == null)
            {
                Console.WriteLine("Курс не найден.");
                return;
            }

            db.Courses.Remove(course);
            db.SaveChanges();
            Console.WriteLine("Курс успешно удален.");
        }

        // Методы для работы с учителями
        static void ReadTeachers(AppContext db)
        {
            var teachers = db.Teachers.ToList();
            if (teachers.Count == 0)
            {
                Console.WriteLine("Список учителей пуст.");
                return;
            }

            Console.WriteLine("Список учителей:");
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"ID: {teacher.TeacherId}, Имя: {teacher.FirstName}, Фамилия: {teacher.LastName}");
            }
        }

        static void AddTeacher(AppContext db)
        {
            Console.Write("Введите имя: ");
            string firstName = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            string lastName = Console.ReadLine();

            var teacher = new Teacher
            {
                FirstName = firstName,
                LastName = lastName
            };

            db.Teachers.Add(teacher);
            db.SaveChanges();
            Console.WriteLine("Учитель успешно добавлен.");
        }

        static void UpdateTeachers(AppContext db)
        {
            Console.Write("Введите ID учителя для обновления: ");
            int id = int.Parse(Console.ReadLine());
            var teacher = db.Teachers.Find(id);

            if (teacher == null)
            {
                Console.WriteLine("Учитель не найден.");
                return;
            }

            Console.Write("Введите новое имя: ");
            string newFirstName = Console.ReadLine();
            Console.Write("Введите новую фамилию: ");
            string newLastName = Console.ReadLine();

            teacher.FirstName = newFirstName;
            teacher.LastName = newLastName;

            db.SaveChanges();
            Console.WriteLine("Курс успешно обновлен.");
        }

        static void DeleteTeacher(AppContext db)
        {
            Console.Write("Введите ID учителя для удаления: ");
            int id = int.Parse(Console.ReadLine());
            var teacher = db.Teachers.Find(id);

            if (teacher == null)
            {
                Console.WriteLine("Учитель не найден.");
                return;
            }

            db.Teachers.Remove(teacher);
            db.SaveChanges();
            Console.WriteLine("Учитель успешно удален.");
        }

        // Пример ленивой загрузки
        static void LazyLoadingExample(AppContext db)
        {
            Console.WriteLine("--- ЛЕНИВАЯ ЗАГРУЗКА ---");

            var studentLazy = db.Students.OrderBy(s => s.StudentId).FirstOrDefault();
            
            if (studentLazy != null)
            {
                Console.WriteLine($"Студент: {studentLazy.FirstName} {studentLazy.LastName}");
                foreach (var enrollment in studentLazy.Enrollments)
                {
                    Console.WriteLine($"  Курс: {enrollment.Course.CourseName}");
                }
            }
            else
            {
                Console.WriteLine("Студенты не найдены.");
            }
        }
    }
}