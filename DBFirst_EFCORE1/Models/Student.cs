using System;
using System.Collections.Generic;

namespace DBFirst_EFCORE1.Models;

public partial class Student
{
    public int Rno { get; set; }

    public string? Name { get; set; }

    public string? Course { get; set; }
}
