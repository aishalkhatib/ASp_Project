using System;
using System.Collections.Generic;

namespace WaterDistribution_MS.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public int? AreaId { get; set; }

    public virtual Area? Area { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
