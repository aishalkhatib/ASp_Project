using System;
using System.Collections.Generic;

namespace WaterDistribution_MS.Models;

public partial class TankArea
{
    public int TankAreaId { get; set; }

    public int? TankId { get; set; }

    public int? AreaId { get; set; }

    public virtual Area? Area { get; set; }

    public virtual Tank? Tank { get; set; }
}
