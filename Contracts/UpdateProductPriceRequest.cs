using System.ComponentModel.DataAnnotations;

public class UpdateProductPriceRequest
    {
        [Range(typeof(decimal), "0.01", "1000000",
            ParseLimitsInInvariantCulture = true, ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }
    }
