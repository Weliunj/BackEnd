using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Account
{
    public int Uid { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string CharName { get; set; } = null!;

    public virtual ICollection<Play> Plays { get; set; } = new List<Play>();
}
