using System;
using System.Collections.Generic;

namespace WaterDistribution_MS.Models;

public partial class Area
{
    public int AreaId { get; set; }

    public string AreaName { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<TankArea> TankAreas { get; set; } = new List<TankArea>();
}
