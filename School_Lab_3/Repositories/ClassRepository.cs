using Microsoft.EntityFrameworkCore;
using School_Lab_3.Models;

public class ClassRepository
{
    private readonly School_Lab_3DbContext _context;

    public ClassRepository(School_Lab_3DbContext context)
    {
        _context = context;
    }

    // Get all classes sorted by name
    public async Task<List<Class>> GetAllClassesAsync()
    {
        return await _context.Classes
            .OrderBy(c => c.ClassName)
            .ToListAsync();
    }

    // Get students in a specific class
    public async Task<List<Student>> GetStudentsInClassAsync(int classId)
    {
        var classEntity = await _context.Classes
            .Include(c => c.Students)
            .FirstOrDefaultAsync(c => c.ClassId == classId);

        return classEntity?.Students.ToList() ?? new List<Student>();
    }

    // Add a new class
    public async Task AddNewClassAsync(string className, string description)
    {
        var newClass = new Class
        {
            ClassName = className,
            Description = description
        };

        _context.Classes.Add(newClass);
        await _context.SaveChangesAsync();
    }
}
