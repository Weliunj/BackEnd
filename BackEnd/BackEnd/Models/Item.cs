using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Item
{
    public int Iid { get; set; }

    public string Iname { get; set; } = null!;

    public string? Img { get; set; }

    public int? Iprice { get; set; }

    public string? Ikind { get; set; }

    public string Ides { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<Quest> Quests { get; set; } = new List<Quest>();

    public virtual ICollection<Transation> Transations { get; set; } = new List<Transation>();
}
