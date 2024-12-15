using System;
using System.Collections.Generic;

namespace School_Lab_3.Models;

public partial class ClassAttendance
{
    public int AttendanceId { get; set; }

    public string? Status { get; set; }

    public DateOnly? Date { get; set; }

    public int? StudentId { get; set; }

    public int? ClassId { get; set; }

    public virtual Class? Class { get; set; }

    public virtual Student? Student { get; set; }
}
