using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class DoQuest
{
    public int DqId { get; set; }

    public bool? Status { get; set; }

    public DateOnly? Time { get; set; }

    public int QId { get; set; }

    public int PId { get; set; }

    public virtual Play PIdNavigation { get; set; } = null!;

    public virtual Quest QIdNavigation { get; set; } = null!;
}
