using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Resource
{
    public int RId { get; set; }

    public string RName { get; set; } = null!;

    public string? RImg { get; set; }

    public virtual ICollection<PlayResource> PlayResources { get; set; } = new List<PlayResource>();

    public virtual ICollection<RecipeDetail> RecipeDetails { get; set; } = new List<RecipeDetail>();
}
