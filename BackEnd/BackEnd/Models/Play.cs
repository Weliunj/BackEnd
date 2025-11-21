using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Play
{
    public int PId { get; set; }

    public int UId { get; set; }

    public int MId { get; set; }

    public string WorldName { get; set; } = null!;

    public DateOnly Time { get; set; }

    public int? Exp { get; set; }

    public double? Hunger { get; set; }

    public double? Health { get; set; }

    public virtual ICollection<Craft> Crafts { get; set; } = new List<Craft>();

    public virtual ICollection<DoQuest> DoQuests { get; set; } = new List<DoQuest>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual Mode MIdNavigation { get; set; } = null!;

    public virtual ICollection<PlayResource> PlayResources { get; set; } = new List<PlayResource>();

    public virtual Account UIdNavigation { get; set; } = null!;
}
