using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace warehouse.Api.Models.DbFirst;

[ApiController]
[Route("api/dbfirst/products")]
public class ProductsDbFirstController : ControllerBase
{
    private readonly WarehouseDbFirstContext _context;

    public ProductsDbFirstController(WarehouseDbFirstContext context)
    {
        _context = context;
    }

    private static readonly Expression<Func<Product, ProductDbFirstResponse>> ToResponse =
        p => new ProductDbFirstResponse
        {
            ProductId = p.ProductId,
            Name = p.Name,
            Price = p.Price,
            Quantity = p.Quantity,
            ExpiryDate = p.ExpiryDate,
            CreatedAt = p.CreatedAt,
            IsArchived = p.IsArchived,
            SupplierId = p.SupplierId,
            SupplierName = p.Supplier.Name
        };

            [HttpGet("by-supplier")]
        public async Task<IActionResult> GetBySupplier(string supplierName, bool ascending = true)
        {
            var query = _context.Products
                .Where(p => p.Supplier.Name == supplierName);

            query = ascending
                ? query.OrderBy(p => p.CreatedAt)
                : query.OrderByDescending(p => p.CreatedAt);

            return Ok(await query.Select(ToResponse).ToListAsync());
        }
        [HttpGet("group-by-expiry-year")]
        public async Task<IActionResult> GroupByExpiryYear()
        {
            var result = await _context.Products
                .GroupBy(p => p.ExpiryDate.Year)
                .Select(g => new { Year = g.Key, Products = g.AsQueryable().Select(ToResponse).ToList() })
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("group-by-expiry-year-country")]
        public async Task<IActionResult> GroupByExpiryYearAndCountry()
        {
            var result = await _context.Products
                .GroupBy(p => new { Year = p.ExpiryDate.Year, p.Supplier.Country })
                .Select(g => new { g.Key.Year, g.Key.Country, Products = g.AsQueryable().Select(ToResponse).ToList() })
                .ToListAsync();

            return Ok(result);
        }
        [HttpGet("count")]
        public async Task<IActionResult> GetTotalCount()
        {
            return Ok(await _context.Products.CountAsync());
        }
        [HttpGet("page")]
        public async Task<IActionResult> GetPage(int pageNumber = 1, int pageSize = 10)
        {
            var products = await _context.Products
                .OrderBy(p => p.ProductId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(ToResponse)
                .ToListAsync();

            return Ok(products);
        }

}
