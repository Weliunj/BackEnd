using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Recipe
{
    public int Recid { get; set; }

    public string RecName { get; set; } = null!;

    public string RecImg { get; set; } = null!;

    public string RecDes { get; set; } = null!;

    public virtual ICollection<Craft> Crafts { get; set; } = new List<Craft>();

    public virtual ICollection<Recipedetail> Recipedetails { get; set; } = new List<Recipedetail>();
}
