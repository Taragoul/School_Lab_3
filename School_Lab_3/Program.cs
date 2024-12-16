using School_Lab_3.Models;               // Namespace for the DbContext and Models
using School_Lab_3.Repositories;          // Namespace for the Repositories
using School_Lab_3.Views;                // Namespace for the Menus

class Program
{
    static async Task Main(string[] args)
    {
        // Manually instantiate the DbContext
        var dbContext = new School_Lab_3DbContext();

        // Manually instantiate the repositories
        var personnelRepository = new PersonnelRepository(dbContext);
        var studentRepository = new StudentRepository(dbContext);
        var classRepository = new ClassRepository(dbContext);
        var gradeRepository = new GradeRepository(dbContext);

        // Manually instantiate the menus, passing the repositories
        var personnelMenu = new PersonnelMenu(personnelRepository);
        var studentMenu = new StudentMenu(studentRepository);
        var classMenu = new ClassMenu(classRepository);
        var gradeMenu = new GradeMenu(gradeRepository);

        // Manually instantiate the MainMenu, passing the submenus
        var mainMenu = new MainMenu(personnelMenu, studentMenu, classMenu, gradeMenu);

        // Run the program
        await mainMenu.DisplayMenuAsync();
    }
}
