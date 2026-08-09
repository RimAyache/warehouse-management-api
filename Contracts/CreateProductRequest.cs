using System.ComponentModel.DataAnnotations;

public class CreateProductRequest
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string SKU { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Range(typeof(decimal), "0.01", "1000000",
            ParseLimitsInInvariantCulture = true, ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int QuantityInStock { get; set; }

        [Required]
        [StringLength(200)]
        public string SupplierName { get; set; }

        public DateTime? ExpiryDate { get; set; }
    }
