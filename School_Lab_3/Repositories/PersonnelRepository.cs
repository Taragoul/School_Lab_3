using Microsoft.EntityFrameworkCore;
using School_Lab_3.Models;

namespace School_Lab_3.Repositories;

public static class PersonnelRepository
{
    // Returns a string of all Personnel.
    public static string AllPersonnel()
    {
        using (var context = new School_Lab_3DbContext())
        {
            var query = context.Personnel
                .Select(e => $"{e.FirstName} {e.LastName} {e.Role}");

            var result = string.Join("\n", new[]
            {
                "All Personnel",
                string.Join("\n", query)
            });

            return result;
        }
    }
}
