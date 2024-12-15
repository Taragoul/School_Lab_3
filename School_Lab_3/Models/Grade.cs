using System;
using System.Collections.Generic;

namespace School_Lab_3.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public string? Grade1 { get; set; }

    public DateOnly? DateSet { get; set; }

    public int? StudentId { get; set; }

    public int? ClassId { get; set; }

    public int? TeacherId { get; set; }

    public virtual Class? Class { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Personnel? Teacher { get; set; }
}
