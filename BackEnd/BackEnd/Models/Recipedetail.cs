using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class RecipeDetail
{
    public int RcldId { get; set; }

    public int RId { get; set; }

    public int RcId { get; set; }

    public int? Quantity { get; set; }

    public virtual Resource RIdNavigation { get; set; } = null!;

    public virtual Recipe Rc { get; set; } = null!;
}
