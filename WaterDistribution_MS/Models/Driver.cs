using System;
using System.Collections.Generic;

namespace WaterDistribution_MS.Models;

public partial class Driver
{
    public int DriverId { get; set; }

    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
}
