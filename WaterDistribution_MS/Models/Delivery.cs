using System;
using System.Collections.Generic;

namespace WaterDistribution_MS.Models;

public partial class Delivery
{
    public int DeliveryId { get; set; }

    public int? OrderId { get; set; }

    public int? DriverId { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public string? Notes { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual Order? Order { get; set; }
}
