namespace warehouse.Api.ViewModels
{
    public class SupplierViewModel
    {
        public Guid SupplierId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string ContactEmail { get; set; }
        public bool IsActive { get; set; }
    }
}