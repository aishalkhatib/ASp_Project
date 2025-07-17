using System;
using System.Collections.Generic;

namespace WaterDistribution_MS.Models;

public partial class Tank
{
    public int TankId { get; set; }

    public int Capacity { get; set; }

    public string? Location { get; set; }

    public string? WaterType { get; set; }

    public decimal? PricePerBarrel { get; set; }

    public bool? IsAvailable { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<TankArea> TankAreas { get; set; } = new List<TankArea>();
}
