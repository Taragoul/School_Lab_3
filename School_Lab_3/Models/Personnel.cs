using System;
using System.Collections.Generic;

namespace School_Lab_3.Models;

public partial class Personnel
{
    public int PersonnelId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
