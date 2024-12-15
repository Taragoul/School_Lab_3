using System;
using System.Collections.Generic;

namespace School_Lab_3.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string? ClassName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<ClassAttendance> ClassAttendances { get; set; } = new List<ClassAttendance>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
