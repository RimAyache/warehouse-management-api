namespace warehouse.Api.ViewModels
{
    public class ProductViewModel
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsArchived { get; set; }
        public Guid? SupplierId { get; set; }
        public string SupplierName { get; set; }
    }
}