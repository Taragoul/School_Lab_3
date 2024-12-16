using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School_Lab_3.Models;

namespace School_Lab_3.Repositories
{
    public class GradeRepository
    {
        private readonly School_Lab_3DbContext _context;

        public GradeRepository(School_Lab_3DbContext context)
        {
            _context = context;
        }

        // Get Grades from the Current Month (Student, Class, Grade)
        public async Task<List<(string FirstName, string LastName, string ClassName, string Grade)>> GetGradesFromCurrentMonthAsync()
        {
            var currentDate = DateTime.Now;
            var currentMonthDate = currentDate;

            var gradesFromCurrentMonth = await (from grade in _context.Grades
                                                join student in _context.Students on grade.StudentId equals student.StudentId
                                                join classInfo in _context.Classes on grade.ClassId equals classInfo.ClassId
                                                where grade.DateSet.HasValue
                                                      && grade.DateSet.Value.Month == currentMonthDate.Month
                                                      && grade.DateSet.Value.Year == currentMonthDate.Year
                                                select new
                                                {
                                                    student.FirstName,
                                                    student.LastName,
                                                    classInfo.ClassName,
                                                    grade.Grade1
                                                }).ToListAsync();

            return gradesFromCurrentMonth.Select(g => (
                g.FirstName,
                g.LastName,
                g.ClassName,
                g.Grade1
            )).ToList();
        }

        // Get Grades from Current Month with Averages, Highest, and Lowest Grades
        public async Task<List<(string ClassName, double AverageGrade, string HighestGrade, string LowestGrade)>> GetGradesWithStatsFromCurrentMonthAsync()
        {
            var currentDate = DateTime.Now;
            var currentMonthDate = currentDate;

            var grades = await (from grade in _context.Grades
                                join classInfo in _context.Classes on grade.ClassId equals classInfo.ClassId
                                where grade.DateSet.HasValue
                                      && grade.DateSet.Value.Month == currentMonthDate.Month
                                      && grade.DateSet.Value.Year == currentMonthDate.Year
                                select new
                                {
                                    classInfo.ClassName,
                                    grade.Grade1
                                }).ToListAsync();

            var classStats = grades
                .GroupBy(g => g.ClassName)
                .Select(group => new
                {
                    ClassName = group.Key,
                    AverageGrade = group.Average(g => ConvertGradeToNumeric(g.Grade1)),
                    HighestGrade = group.Max(g => ConvertGradeToNumeric(g.Grade1)),
                    LowestGrade = group.Min(g => ConvertGradeToNumeric(g.Grade1))
                })
                .ToList();

            return classStats.Select(stat => (
                stat.ClassName,
                stat.AverageGrade,
                ConvertNumericToGrade(stat.HighestGrade),
                ConvertNumericToGrade(stat.LowestGrade)
            )).ToList();
        }

        // Get Grades from the Previous Month (Student, Class, Grade)
        public async Task<List<(string FirstName, string LastName, string ClassName, string Grade)>> GetGradesFromPreviousMonthAsync()
        {
            var currentDate = DateTime.Now;
            var previousMonthDate = currentDate.AddMonths(-1);

            var gradesFromPreviousMonth = await (from grade in _context.Grades
                                                 join student in _context.Students on grade.StudentId equals student.StudentId
                                                 join classInfo in _context.Classes on grade.ClassId equals classInfo.ClassId
                                                 where grade.DateSet.HasValue
                                                       && grade.DateSet.Value.Month == previousMonthDate.Month
                                                       && grade.DateSet.Value.Year == previousMonthDate.Year
                                                 select new
                                                 {
                                                     student.FirstName,
                                                     student.LastName,
                                                     classInfo.ClassName,
                                                     grade.Grade1
                                                 }).ToListAsync();

            return gradesFromPreviousMonth.Select(g => (
                g.FirstName,
                g.LastName,
                g.ClassName,
                g.Grade1
            )).ToList();
        }

        // Get Grades from Previous Month with Averages, Highest, and Lowest Grades
        public async Task<List<(string ClassName, double AverageGrade, string HighestGrade, string LowestGrade)>> GetGradesWithStatsFromPreviousMonthAsync()
        {
            var currentDate = DateTime.Now;
            var previousMonthDate = currentDate.AddMonths(-1);

            var grades = await (from grade in _context.Grades
                                join classInfo in _context.Classes on grade.ClassId equals classInfo.ClassId
                                where grade.DateSet.HasValue
                                      && grade.DateSet.Value.Month == previousMonthDate.Month
                                      && grade.DateSet.Value.Year == previousMonthDate.Year
                                select new
                                {
                                    classInfo.ClassName,
                                    grade.Grade1
                                }).ToListAsync();

            var classStats = grades
                .GroupBy(g => g.ClassName)
                .Select(group => new
                {
                    ClassName = group.Key,
                    AverageGrade = group.Average(g => ConvertGradeToNumeric(g.Grade1)),
                    HighestGrade = group.Max(g => ConvertGradeToNumeric(g.Grade1)),
                    LowestGrade = group.Min(g => ConvertGradeToNumeric(g.Grade1))
                })
                .ToList();

            return classStats.Select(stat => (
                stat.ClassName,
                stat.AverageGrade,
                ConvertNumericToGrade(stat.HighestGrade),
                ConvertNumericToGrade(stat.LowestGrade)
            )).ToList();
        }

        // Helper method to convert a letter grade to a numeric value
        public static double ConvertGradeToNumeric(string grade)
        {
            return grade.ToUpper() switch
            {
                "A" => 4.0,
                "B" => 3.0,
                "C" => 2.0,
                "D" => 1.0,
                "F" => 0.0,
                _ => 0.0
            };
        }

        // Helper method to convert numeric grade to letter grade
        public static string ConvertNumericToGrade(double numericGrade)
        {
            return numericGrade switch
            {
                >= 4.0 => "A",
                >= 3.0 => "B",
                >= 2.0 => "C",
                >= 1.0 => "D",
                >= 0.0 => "F",
                _ => "F"
            };
        }
    }
}
