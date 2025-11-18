using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Play
{
    public int Pid { get; set; }

    public int Uid { get; set; }

    public int Mid { get; set; }

    public string WorldName { get; set; } = null!;

    public DateOnly? Time { get; set; }

    public int? Exp { get; set; }

    public double? Hunger { get; set; }

    public double? Heath { get; set; }

    public virtual ICollection<Craft> Crafts { get; set; } = new List<Craft>();

    public virtual ICollection<DoQuest> DoQuests { get; set; } = new List<DoQuest>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual Mode MidNavigation { get; set; } = null!;

    public virtual ICollection<Transation> Transations { get; set; } = new List<Transation>();

    public virtual Account UidNavigation { get; set; } = null!;
}
