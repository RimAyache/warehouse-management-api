 [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    { 
        [HttpGet]
        public ActionResult<List<Product>> GetAll([FromQuery] bool onlyAvailable = false)
        {
            List<Product> products = FakeWarehouseStore.Products;

            if (onlyAvailable)
            {
                products = products.Where(p => !p.IsArchived).ToList();
            }

            products = products.OrderByDescending(p => p.CreatedAt).ToList();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid product id");
            }
            var product = FakeWarehouseStore.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("search")]
        public ActionResult<List<Product>> Search([FromQuery] string? name, [FromQuery] string? supplier)
        {
            List<Product> products = FakeWarehouseStore.Products;

            if (!string.IsNullOrWhiteSpace(name))
            {
                products = products
                    .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            if (!string.IsNullOrWhiteSpace(supplier))
            {
                    products = products
                        .Where(p => p.SupplierName != null &&
                                    p.SupplierName.Contains(supplier, StringComparison.OrdinalIgnoreCase))
                        .ToList();
            }
            if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(supplier))
            {
                return BadRequest("At least one parameter should be provided");
            }
            return Ok(products);
                }
    }