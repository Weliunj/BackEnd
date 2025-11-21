using System;
using System.Collections.Generic;

namespace BackEnd.Models;

public partial class PlayResource
{
    public int PrId { get; set; }

    public int PId { get; set; }

    public int RId { get; set; }

    public int? Quantity { get; set; }

    public virtual Play PIdNavigation { get; set; } = null!;

    public virtual Resource RIdNavigation { get; set; } = null!;
}
