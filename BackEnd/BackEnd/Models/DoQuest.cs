using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class DoQuest
{
    public int Dqid { get; set; }

    public bool? Status { get; set; }

    public DateOnly Time { get; set; }

    public int Pid { get; set; }

    public int Qid { get; set; }

    public virtual Play PidNavigation { get; set; } = null!;

    public virtual Quest QidNavigation { get; set; } = null!;
}
