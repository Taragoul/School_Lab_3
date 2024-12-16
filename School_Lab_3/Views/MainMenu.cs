using School_Lab_3.Repositories;
namespace School_Lab_3.Views;
public class MainMenu
{
    private readonly PersonnelMenu _personnelMenu;
    private readonly StudentMenu _studentMenu;
    private readonly ClassMenu _classMenu;
    private readonly GradeMenu _gradeMenu;

    public MainMenu(
        PersonnelMenu personnelMenu,
        StudentMenu studentMenu,
        ClassMenu classMenu,
        GradeMenu gradeMenu)
    {
        _personnelMenu = personnelMenu;
        _studentMenu = studentMenu;
        _classMenu = classMenu;
        _gradeMenu = gradeMenu;
    }

    public async Task DisplayMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("School Management System");
            Console.WriteLine("1. Personnel");
            Console.WriteLine("2. Students");
            Console.WriteLine("3. Classes");
            Console.WriteLine("4. Grades");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await _personnelMenu.DisplayMenuAsync();
                    break;
                case "2":
                    await _studentMenu.DisplayMenuAsync();
                    break;
                case "3":
                    await _classMenu.DisplayMenuAsync();
                    break;
                case "4":
                    await _gradeMenu.DisplayMenuAsync();
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
}
