using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Quest
{
    public int QId { get; set; }

    public string QName { get; set; } = null!;

    public int? Exp { get; set; }

    public int? IId { get; set; }

    public int? MId { get; set; }

    public virtual ICollection<DoQuest> DoQuests { get; set; } = new List<DoQuest>();

    public virtual Item? IIdNavigation { get; set; }

    public virtual Mode? MIdNavigation { get; set; }
}
