using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Craft
{
    public int Cid { get; set; }

    public DateOnly Time { get; set; }

    public int Pid { get; set; }

    public int Rid { get; set; }

    public virtual Play PidNavigation { get; set; } = null!;

    public virtual Recipe RidNavigation { get; set; } = null!;
}
