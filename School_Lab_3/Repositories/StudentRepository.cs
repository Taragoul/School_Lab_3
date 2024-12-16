using School_Lab_3.Models;
using Microsoft.EntityFrameworkCore;

public class StudentRepository
{
    private readonly School_Lab_3DbContext _context;

    public StudentRepository(School_Lab_3DbContext context)
    {
        _context = context;
    }
    // Retrieve all students
    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        return await _context.Students
            .OrderBy(s => s.LastName) // Default sorting by LastName
            .ThenBy(s => s.FirstName) // Secondary sorting by FirstName
            .ToListAsync();
    }

    // Retrieve students sorted by FirstName or LastName
    public async Task<IEnumerable<Student>> GetSortedStudentsAsync(bool sortByFirstName, bool ascending)
    {
        if (sortByFirstName)
        {
            return ascending
                ? await _context.Students.OrderBy(s => s.FirstName).ToListAsync()
                : await _context.Students.OrderByDescending(s => s.FirstName).ToListAsync();
        }
        else
        {
            return ascending
                ? await _context.Students.OrderBy(s => s.LastName).ToListAsync()
                : await _context.Students.OrderByDescending(s => s.LastName).ToListAsync();
        }
    }

    // Retrieve all students in a specific class
    public async Task<IEnumerable<Student>> GetStudentsByClassAsync(int classId)
    {
        var classEntity = await _context.Classes
            .Include(c => c.Students)
            .FirstOrDefaultAsync(c => c.ClassId == classId);

        return classEntity?.Students ?? new List<Student>();
    }

// Add new student
public async Task AddNewStudentAsync(string firstName, string lastName, string email)
    {
        var student = new Student
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email
        };

        _context.Students.Add(student);
        await _context.SaveChangesAsync();
    }
}
