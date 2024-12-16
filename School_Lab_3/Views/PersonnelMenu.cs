using School_Lab_3.Repositories;
namespace School_Lab_3.Views;
public class PersonnelMenu
{
    private readonly PersonnelRepository _personnelRepository;

    public PersonnelMenu(PersonnelRepository personnelRepository)
    {
        _personnelRepository = personnelRepository;
    }

    public async Task DisplayMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Personnel Menu");
            Console.WriteLine("1. View All Personnel");
            Console.WriteLine("2. View Personnel By Role");
            Console.WriteLine("3. Add New Personnel");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Enter your choice: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var allPersonnel = await _personnelRepository.GetAllPersonnelAsync();
                    foreach (var person in allPersonnel)
                        Console.WriteLine($"{person.FirstName} {person.LastName} ({person.Role})");
                    break;
                case "2":
                    Console.Write("Enter Role (e.g., Teacher, Admin): ");
                    var role = Console.ReadLine();
                    var personnelByRole = await _personnelRepository.GetPersonnelByRoleAsync(role);
                    foreach (var person in personnelByRole)
                        Console.WriteLine($"{person.FirstName} {person.LastName} ({person.Role})");
                    break;
                case "3":
                    Console.Write("Enter First Name: ");
                    var firstName = Console.ReadLine();
                    Console.Write("Enter Last Name: ");
                    var lastName = Console.ReadLine();
                    Console.Write("Enter Email: ");
                    var email = Console.ReadLine();
                    Console.Write("Enter Role: ");
                    var personnelRole = Console.ReadLine();
                    await _personnelRepository.AddNewPersonnelAsync(firstName, lastName, email, personnelRole);
                    Console.WriteLine("Personnel added successfully!");
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again...");
                    Console.ReadLine();
                    break;
            }

            Console.WriteLine("Press Enter to return to the Personnel Menu...");
            Console.ReadLine();
        }
    }
}
