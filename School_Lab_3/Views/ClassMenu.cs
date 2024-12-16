using System;
using System.Linq;
using System.Threading.Tasks;
using School_Lab_3.Repositories;

namespace School_Lab_3.Views;

public class ClassMenu
    {
        private readonly ClassRepository _classRepository;

        public ClassMenu(ClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task DisplayMenuAsync()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Class Menu ===");
                Console.WriteLine("1. View All Classes");
                Console.WriteLine("2. View Students in a Class");
                Console.WriteLine("0. Back to Main Menu");

                Console.Write("\nSelect an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await ViewAllClassesAsync();
                        break;

                    case "2":
                        await ViewStudentsInClassAsync();
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private async Task ViewAllClassesAsync()
        {
            Console.Clear();
            var classes = await _classRepository.GetAllClassesAsync();
            if (!classes.Any())
            {
                Console.WriteLine("No classes available.");
            }
            else
            {
                Console.WriteLine("=== Classes ===");
                foreach (var c in classes)
                {
                    Console.WriteLine($"{c.ClassName} - {c.Description}");
                }
            }
            Console.WriteLine("\nPress any key to return to the menu.");
            Console.ReadKey();
        }

        private async Task ViewStudentsInClassAsync()
        {
            Console.Clear();
            var classes = await _classRepository.GetAllClassesAsync();
            if (!classes.Any())
            {
                Console.WriteLine("No classes available.");
                Console.WriteLine("\nPress any key to return to the menu.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("=== Select a Class ===");
            foreach (var c in classes.OrderBy(cls => cls.ClassId))
            {
                Console.WriteLine($"{c.ClassId}: {c.ClassName}");
            }

            Console.Write("\nEnter the Class ID: ");
            if (int.TryParse(Console.ReadLine(), out int classId))
            {
                var students = await _classRepository.GetStudentsInClassAsync(classId);
                if (!students.Any())
                {
                    Console.WriteLine("No students found for the selected class.");
                }
                else
                {
                    Console.WriteLine($"\n=== Students in Class {classId} ===");
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.FirstName} {student.LastName}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Class ID.");
            }
            Console.WriteLine("\nPress any key to return to the menu.");
            Console.ReadKey();
        }
    }

