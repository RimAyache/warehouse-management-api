using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using warehouse.Api.Models;
using warehouse.Api.ViewModels;

namespace warehouse.Api.Controllers
{
    [ApiController]
    [Route("api/codefirst/products")]
    public class CodeFirstProductsController : ControllerBase
    {
        private readonly WarehouseDbContext _context;
        private readonly IMapper _mapper;

        public CodeFirstProductsController(WarehouseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> GetProduct(Guid id)
        {
            var product = await _context.Products.Include(p => p.Supplier).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();

            return Ok(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> AddProduct(Product product)
        {
            if (product.SupplierId.HasValue)
            {
                var supplierExists = await _context.Suppliers.AnyAsync(s => s.Id == product.SupplierId);
                if (!supplierExists) return BadRequest("Supplier does not exist.");
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            await _context.Entry(product).Reference(p => p.Supplier).LoadAsync();

            var vm = _mapper.Map<ProductViewModel>(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, vm);
        }

        [HttpPatch("{id}/price")]
        public async Task<ActionResult<ProductViewModel>> UpdatePrice(Guid id, [FromBody] decimal newPrice)
        {
            var product = await _context.Products.Include(p => p.Supplier).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();

            product.Price = newPrice;
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPatch("{id}/quantity")]
        public async Task<ActionResult<ProductViewModel>> UpdateQuantity(Guid id, [FromBody] int newQuantity)
        {
            var product = await _context.Products.Include(p => p.Supplier).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();

            product.QuantityInStock = newQuantity;
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<ProductViewModel>(product));
        }


        [HttpPatch("{id}/archive")]
        public async Task<ActionResult<ProductViewModel>> ArchiveProduct(Guid id)
        {
            var product = await _context.Products.Include(p => p.Supplier).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();

            product.IsArchived = true;
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPatch("{id}/assign-supplier")]
        public async Task<ActionResult<ProductViewModel>> AssignSupplier(Guid id, [FromBody] Guid supplierId)
        {
            var product = await _context.Products.Include(p => p.Supplier).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();

            var supplierExists = await _context.Suppliers.AnyAsync(s => s.Id == supplierId);
            if (!supplierExists) return BadRequest("Supplier does not exist.");

            product.SupplierId = supplierId;
            await _context.SaveChangesAsync();
            await _context.Entry(product).Reference(p => p.Supplier).LoadAsync();

            return Ok(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost("{productId}/images")]
        public async Task<IActionResult> UploadImage(Guid productId, IFormFile file)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) return NotFound();

            if (file == null || file.Length == 0) return BadRequest("No file uploaded.");

            var uploadsFolder = Path.Combine("wwwroot", "uploads");
            Directory.CreateDirectory(uploadsFolder);
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var image = new ProductImage
            {
                Id = Guid.NewGuid(),
                ProductId = productId,
                FileName = fileName,
                FilePath = $"/uploads/{fileName}"
            };
            _context.ProductImages.Add(image);
            await _context.SaveChangesAsync();

            return Ok(image);
        }
    }
}
