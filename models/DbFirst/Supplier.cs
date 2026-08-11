using System;
using System.Collections.Generic;

namespace warehouse.Api.Models.DbFirst;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string? ContactEmail { get; set; }

    public string? PhoneNumber { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
