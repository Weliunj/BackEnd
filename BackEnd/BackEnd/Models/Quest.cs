using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Quest
{
    public int Qid { get; set; }

    public string QName { get; set; } = null!;

    public int? QExp { get; set; }

    public int? Mid { get; set; }

    public int? Iid { get; set; }

    public virtual ICollection<DoQuest> DoQuests { get; set; } = new List<DoQuest>();

    public virtual Item? IidNavigation { get; set; }

    public virtual Mode? MidNavigation { get; set; }
}
