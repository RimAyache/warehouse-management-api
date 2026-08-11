public class ProductDbFirstResponse
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public DateOnly ExpiryDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsArchived { get; set; }

        public int SupplierId { get; set; }

        public string SupplierName { get; set; }
    }
