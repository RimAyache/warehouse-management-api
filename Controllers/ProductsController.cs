using Microsoft.AspNetCore.Mvc;
using System.Globalization;

 [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> thislogger;
        private readonly IWebHostEnvironment environment;

        public ProductsController(ILogger<ProductsController> logger, IWebHostEnvironment env)
        {
            thislogger = logger;
            environment = env;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll(
            [FromQuery] bool onlyAvailable = false,
            [FromQuery] bool includeArchived = false)
        {
            IEnumerable<Product> products = FakeWarehouseStore.Products;

            if (!includeArchived)
            {
                products = products.Where(p => !p.IsArchived);
            }

            if (onlyAvailable)
            {
                products = products.Where(p => p.QuantityInStock > 0);
            }

            return Ok(products.OrderByDescending(p => p.CreatedAt).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid product id");
            }
            
            var product = FakeWarehouseStore.Products.FirstOrDefault(p => p.Id == id);
;
            if (product == null || product.IsArchived)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("search")]
        public ActionResult<List<Product>> Search([FromQuery] string? name, [FromQuery] string? supplier)
        {
            if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(supplier))
            {
                return BadRequest("At least one parameter should be provided");
            }

            IEnumerable<Product> products = FakeWarehouseStore.Products.Where(p => !p.IsArchived);

            if (!string.IsNullOrWhiteSpace(name))
            {
                products = products
                    .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrWhiteSpace(supplier))
            {
                products = products
                    .Where(p => p.SupplierName != null &&
                                p.SupplierName.Contains(supplier, StringComparison.OrdinalIgnoreCase));
            }

            return Ok(products.ToList());
        }

        [HttpPost]
        public ActionResult<Product> Create(CreateProductRequest request)
        {
            bool skuExists = FakeWarehouseStore.Products
                .Any(p => p.SKU.Equals(request.SKU, StringComparison.OrdinalIgnoreCase));

            if (skuExists)
            {
                return BadRequest($"A product with SKU '{request.SKU}' already exists");
            }

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                SKU = request.SKU,
                Description = request.Description,
                Price = request.Price,
                QuantityInStock = request.QuantityInStock,
                SupplierName = request.SupplierName,
                ExpiryDate = request.ExpiryDate,
                IsArchived = false,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            };

            FakeWarehouseStore.Products.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPost("{id}/quantity")]
        public ActionResult<Product> UpdateQuantity(Guid id, [FromBody] UpdateProductQuantityRequest request)
        {
            var product = FakeWarehouseStore.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            if (product.IsArchived)
            {
                return Conflict("Cannot modify an archived product");
            }

            product.QuantityInStock = request.QuantityInStock;
            product.LastUpdatedAt = DateTime.UtcNow;

            return Ok(product);
        }

        [HttpPost("{id}/price")]
        public ActionResult<Product> UpdatePrice(Guid id, [FromBody] UpdateProductPriceRequest request)
        {
            var product = FakeWarehouseStore.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            if (product.IsArchived)
            {
                return Conflict("Cannot modify an archived product");
            }

            var oldPrice = product.Price;
            product.Price = request.Price;
            product.LastUpdatedAt = DateTime.UtcNow;

            thislogger.LogInformation(
                "Product {ProductId} price changed from {OldPrice} to {NewPrice}",
                product.Id, oldPrice, product.Price);

            return Ok(product);
        }

        [HttpPost("{id}/image")]
        public async Task<ActionResult<ProductImage>> UploadImage(Guid id, [FromForm] IFormFile file)
        {
            var product = FakeWarehouseStore.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            if (product.IsArchived)
            {
                return Conflict("Cannot modify an archived product");
            }

            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded");
            }

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(extension))
            {
                return BadRequest("Only .jpg and .png files are allowed");
            }

            const long maxFileSize = 2 * 1024 * 1024; 
            if (file.Length > maxFileSize)
            {
                return BadRequest("File size cannot exceed 2 MB");
            }

            var webRoot = environment.WebRootPath ?? Path.Combine(environment.ContentRootPath, "wwwroot");
            var uploadsFolder = Path.Combine(webRoot, "uploads");
            Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var productImage = new ProductImage
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id,
                FileName = uniqueFileName,
                FilePath = $"/uploads/{uniqueFileName}"
            };

            product.Images.Add(productImage);
            product.LastUpdatedAt = DateTime.UtcNow;

            return Ok(productImage);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var product = FakeWarehouseStore.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            product.IsArchived = true;
            product.LastUpdatedAt = DateTime.UtcNow;

            return NoContent();
        }

        [HttpGet("server-time")]
        public IActionResult GetServerTime(
            [FromHeader(Name = "Accept-Language")] string? acceptLanguage)
        {
            var supported = new[] { "en-US", "fr-FR", "ar-LB" };

            var requested = acceptLanguage?.Split(',')[0].Split(';')[0].Trim();

            var language = supported.FirstOrDefault(s => s.Equals(requested, StringComparison.OrdinalIgnoreCase))
                ?? "en-US";

            var culture = CultureInfo.GetCultureInfo(language);

            return Ok(new
            {
                language = culture.Name,
                serverTime = DateTime.UtcNow.ToString(culture)
            });
        }
    }
