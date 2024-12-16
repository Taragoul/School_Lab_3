using School_Lab_3.Repositories;
namespace School_Lab_3.Views;
public class StudentMenu
{
    private readonly StudentRepository _studentRepository;

    public StudentMenu(StudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task DisplayMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Student Menu");
            Console.WriteLine("1. View All Students");
            Console.WriteLine("2. View Sorted Students");
            Console.WriteLine("3. Add New Student");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Enter your choice: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var students = await _studentRepository.GetAllStudentsAsync();
                    foreach (var student in students)
                        Console.WriteLine($"{student.FirstName} {student.LastName}");
                    break;
                case "2":
                    Console.Write("Sort by (1 for First Name, 2 for Last Name): ");
                    var sortBy = Console.ReadLine() == "1";
                    Console.Write("Order (1 for Ascending, 2 for Descending): ");
                    var ascending = Console.ReadLine() == "1";
                    var sortedStudents = await _studentRepository.GetSortedStudentsAsync(sortBy, ascending);
                    foreach (var student in sortedStudents)
                        Console.WriteLine($"{student.FirstName} {student.LastName}");
                    break;
                case "3":
                    Console.Write("Enter First Name: ");
                    var firstName = Console.ReadLine();
                    Console.Write("Enter Last Name: ");
                    var lastName = Console.ReadLine();
                    Console.Write("Enter Email: ");
                    var email = Console.ReadLine();
                    await _studentRepository.AddNewStudentAsync(firstName, lastName, email);
                    Console.WriteLine("Student added successfully!");
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again...");
                    Console.ReadLine();
                    break;
            }

            Console.WriteLine("Press Enter to return to the Student Menu...");
            Console.ReadLine();
        }
    }
}
