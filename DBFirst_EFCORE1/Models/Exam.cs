using System;
using System.Collections.Generic;

namespace DBFirst_EFCORE1.Models;

public partial class Exam
{
    public int? Rno { get; set; }

    public int? Sub1 { get; set; }

    public int? Sub2 { get; set; }

    public virtual Student? RnoNavigation { get; set; }
}
