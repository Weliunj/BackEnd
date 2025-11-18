using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Inventory
{
    public int Ivid { get; set; }

    public int Pid { get; set; }

    public int Iid { get; set; }

    public int? Ivquan { get; set; }

    public virtual Item IidNavigation { get; set; } = null!;

    public virtual Play PidNavigation { get; set; } = null!;
}
