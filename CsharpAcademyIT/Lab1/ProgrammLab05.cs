﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpAcademyIT.Lab1
{
    class ProgrammLab05
    {
        static void MainLab05(string[] args)
        {

            // Имитация данных о студентах и их оценках
            List<Grade> grades = new List<Grade>
            {
            new Grade { StudentName = "Вася", Subject = "Математика", Score = 90 },
            new Grade { StudentName = "Вася", Subject = "Физика", Score = 85 },
            new Grade { StudentName = "Петя", Subject = "Математика", Score = 75 },
            new Grade { StudentName = "Петя", Subject = "Физика", Score = 80 },
            new Grade { StudentName = "Коля", Subject = "Математика", Score = 95 },
            new Grade { StudentName = "Коля", Subject = "Физика", Score = 90 }
        };

            // Список студентов
            List<string> students = new List<string> { "Вася", "Петя", "Коля" };

            // Сервис для работы с данными
            var gradeService = new GradeService();

            // Замер времени выполнения
            var watch = Stopwatch.StartNew();

            // Последовательно вычисляем средний балл для каждого студента
            foreach (var student in students)
            {
                double averageScore = gradeService.CalculateAverageScore(grades, student);
                Console.WriteLine($"Для студента {student} средняя оценка: {averageScore}");
            }

            watch.Stop();

            Console.WriteLine($"Все вычисления завершены. Время выполнения: {watch.ElapsedMilliseconds} мс");
        }
    }
}
