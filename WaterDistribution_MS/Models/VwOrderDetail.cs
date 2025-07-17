using System;
using System.Collections.Generic;

namespace WaterDistribution_MS.Models;

public partial class VwOrderDetail
{
    public int OrderId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string? Phone { get; set; }

    public string AreaName { get; set; } = null!;

    public string? TankLocation { get; set; }

    public string? WaterType { get; set; }

    public decimal? PricePerBarrel { get; set; }

    public int Quantity { get; set; }

    public decimal? TotalPrice { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? Status { get; set; }
}
