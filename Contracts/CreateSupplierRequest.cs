using System.ComponentModel.DataAnnotations;

public class CreateSupplierRequest
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(200)]
        public string ContactEmail { get; set; }

        [Required]
        [Phone]
        [StringLength(30)]
        public string PhoneNumber { get; set; }
    }
