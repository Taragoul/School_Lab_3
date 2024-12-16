using School_Lab_3.Models;
using Microsoft.EntityFrameworkCore;
public class PersonnelRepository
{
    private readonly School_Lab_3DbContext _context;

    public PersonnelRepository(School_Lab_3DbContext context)
    {
        _context = context;
    }
    // Retrieve all personnel
    public async Task<IEnumerable<Personnel>> GetAllPersonnelAsync()
    {
        return await _context.Personnel
            .ToListAsync();
    }

    // Retrieve personnel by role (e.g., Teacher, Admin, Nurse)
    public async Task<IEnumerable<Personnel>> GetPersonnelByRoleAsync(string role)
    {
        return await _context.Personnel
            .Where(p => p.Role == role)
            .ToListAsync();
    }

    // Add new personnel
    public async Task AddNewPersonnelAsync(string firstName, string lastName, string email, string role)
    {
        var personnel = new Personnel
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Role = role
        };

        _context.Personnel.Add(personnel);
        await _context.SaveChangesAsync();
    }
}
