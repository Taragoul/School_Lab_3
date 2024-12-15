using System;
using System.Threading.Tasks;

public class MainMenu
{
    public static async Task ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("School Database Management System");
            Console.WriteLine("1. Personnel");
            Console.WriteLine("2. Students");
            Console.WriteLine("3. Classes");
            Console.WriteLine("4. Grades This Month");
            Console.WriteLine("5. Average Grade");
            Console.WriteLine("6. Add Student");
            Console.WriteLine("7. Add Personnel");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await PersonnelMenu.ShowMenu();
                    break;
                case "2":
                    await StudentMenu.ShowMenu();
                    break;
                case "3":
                    await ClassesMenu.ShowMenu();
                    break;
                case "4":
                    await GradesMenu.ShowGradesThisMonth();
                    break;
                case "5":
                    await GradesMenu.ShowAverageGrades();
                    break;
                case "6":
                    await StudentMenu.AddStudent();
                    break;
                case "7":
                    await PersonnelMenu.AddPersonnel();
                    break;
                case "0":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
