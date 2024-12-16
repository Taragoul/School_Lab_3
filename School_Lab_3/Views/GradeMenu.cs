using School_Lab_3.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School_Lab_3.Views
{
    public class GradeMenu
    {
        private readonly GradeRepository _gradeRepository;

        public GradeMenu(GradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public async Task DisplayMenuAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Grade Management");
                Console.WriteLine("1. View Grades from Current Month");
                Console.WriteLine("2. View Grades with Averages, Highest, and Lowest from Current Month");
                Console.WriteLine("3. View Grades from Previous Month");
                Console.WriteLine("4. View Grades with Averages, Highest, and Lowest from Previous Month");
                Console.WriteLine("5. Back");
                Console.Write("Enter your choice: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await ViewGradesFromCurrentMonthAsync();
                        break;
                    case "2":
                        await ViewGradesWithStatsFromCurrentMonthAsync();
                        break;
                    case "3":
                        await ViewGradesFromPreviousMonthAsync();
                        break;
                    case "4":
                        await ViewGradesWithStatsFromPreviousMonthAsync();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter to try again...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private async Task ViewGradesFromCurrentMonthAsync()
        {
            var grades = await _gradeRepository.GetGradesFromCurrentMonthAsync();
            DisplayGrades(grades);
        }

        private async Task ViewGradesWithStatsFromCurrentMonthAsync()
        {
            var gradesWithStats = await _gradeRepository.GetGradesWithStatsFromCurrentMonthAsync();
            DisplayGradeStats(gradesWithStats);
        }

        private async Task ViewGradesFromPreviousMonthAsync()
        {
            var grades = await _gradeRepository.GetGradesFromPreviousMonthAsync();
            DisplayGrades(grades);
        }

        private async Task ViewGradesWithStatsFromPreviousMonthAsync()
        {
            var gradesWithStats = await _gradeRepository.GetGradesWithStatsFromPreviousMonthAsync();
            DisplayGradeStats(gradesWithStats);
        }

        private void DisplayGrades(List<(string FirstName, string LastName, string ClassName, string Grade)> grades)
        {
            Console.Clear();
            Console.WriteLine("Grades Overview:");

            if (grades.Count == 0)
            {
                Console.WriteLine("No grades available.");
            }
            else
            {
                foreach (var grade in grades)
                {
                    Console.WriteLine($"Student: {grade.FirstName} {grade.LastName}");
                    Console.WriteLine($"Class: {grade.ClassName}");
                    Console.WriteLine($"Grade: {grade.Grade}");
                    Console.WriteLine("---------------");
                }
            }

            Console.WriteLine("Press Enter to return to the menu...");
            Console.ReadLine();
        }

        private void DisplayGradeStats(List<(string ClassName, double AverageGrade, string HighestGrade, string LowestGrade)> gradeStats)
        {
            Console.Clear();
            Console.WriteLine("Grade Statistics Overview:");
            Console.WriteLine("Note: The Average Grade is calculated by converting letter grades to numeric values (A = 4, B = 3, C = 2, D = 1, F = 0),");
            Console.WriteLine("and then computing the average of those numeric values for each class.");
            Console.WriteLine("---------------");

            if (gradeStats.Count == 0)
            {
                Console.WriteLine("No grades available.");
            }
            else
            {
                foreach (var stat in gradeStats)
                {
                    Console.WriteLine($"Class: {stat.ClassName}");
                    Console.WriteLine($"Average Grade: {stat.AverageGrade:F2}");
                    Console.WriteLine($"Highest Grade: {stat.HighestGrade}");
                    Console.WriteLine($"Lowest Grade: {stat.LowestGrade}");
                    Console.WriteLine("---------------");
                }
            }

            Console.WriteLine("Press Enter to return to the menu...");
            Console.ReadLine();
        }
    }
}
