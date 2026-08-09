using System.ComponentModel.DataAnnotations;

public class UpdateProductQuantityRequest
    {
        [Range(0, int.MaxValue)]
        public int QuantityInStock { get; set; }
    }
