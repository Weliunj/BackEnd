using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class Recipedetail
{
    public int Rdid { get; set; }

    public int? Rdquan { get; set; }

    public int Rid { get; set; }

    public int Reid { get; set; }

    public virtual Resource Re { get; set; } = null!;

    public virtual Recipe RidNavigation { get; set; } = null!;
}
