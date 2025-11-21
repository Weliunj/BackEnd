using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Recipe
{
    public int RcId { get; set; }

    public string? RcName { get; set; }

    public int IId { get; set; }

    public virtual ICollection<Craft> Crafts { get; set; } = new List<Craft>();

    public virtual Item IIdNavigation { get; set; } = null!;

    public virtual ICollection<RecipeDetail> RecipeDetails { get; set; } = new List<RecipeDetail>();
}
