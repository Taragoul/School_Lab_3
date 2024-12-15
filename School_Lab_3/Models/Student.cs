using System;
using System.Collections.Generic;

namespace School_Lab_3.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<ClassAttendance> ClassAttendances { get; set; } = new List<ClassAttendance>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
