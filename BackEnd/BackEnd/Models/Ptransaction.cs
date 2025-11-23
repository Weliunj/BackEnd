using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Ptransaction
{
    public int Tid { get; set; }

    public int PId { get; set; }

    public int IId { get; set; }

    public DateTime Time { get; set; }

    public bool? Status { get; set; }

    public double? Value { get; set; }

    public virtual Item IIdNavigation { get; set; } = null!;

    public virtual Play PIdNavigation { get; set; } = null!;
}
