using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Resource
{
    public int Rid { get; set; }

    public int? Rquan { get; set; }

    public string Rtype { get; set; } = null!;

    public int Pid { get; set; }

    public virtual ICollection<Recipedetail> Recipedetails { get; set; } = new List<Recipedetail>();
}
