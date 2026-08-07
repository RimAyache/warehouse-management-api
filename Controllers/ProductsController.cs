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
    }