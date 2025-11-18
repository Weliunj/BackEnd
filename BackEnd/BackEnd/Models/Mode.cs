using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Mode
{
    public int Mid { get; set; }

    public string MName { get; set; } = null!;

    public virtual ICollection<Play> Plays { get; set; } = new List<Play>();

    public virtual ICollection<Quest> Quests { get; set; } = new List<Quest>();
}
