using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Transation
{
    public int Tid { get; set; }

    public DateTime Time { get; set; }

    public bool? Status { get; set; }

    public int Pid { get; set; }

    public int Iid { get; set; }

    public virtual Item IidNavigation { get; set; } = null!;

    public virtual Play PidNavigation { get; set; } = null!;
}
