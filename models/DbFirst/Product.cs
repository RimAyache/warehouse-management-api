using System;
using System.Collections.Generic;

namespace warehouse.Api.Models.DbFirst;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public DateOnly ExpiryDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsArchived { get; set; }

    public int SupplierId { get; set; }

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual Supplier Supplier { get; set; } = null!;
}
