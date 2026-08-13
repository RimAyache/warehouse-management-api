using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using warehouse.Api.Models;
using warehouse.Api.ViewModels;

namespace warehouse.Api.Controllers
{
    [ApiController]
    [Route("api/codefirst/suppliers")]
    public class CodeFirstSuppliersController : ControllerBase
    {
        private readonly WarehouseDbContext _context;
        private readonly IMapper _mapper;

        public CodeFirstSuppliersController(WarehouseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierViewModel>> GetSupplier(Guid id)
        {
            var supplier = await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == id);
            if (supplier == null) return NotFound();

            return Ok(_mapper.Map<SupplierViewModel>(supplier));
        }

        [HttpPost]
        public async Task<ActionResult<SupplierViewModel>> AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();

            var vm = _mapper.Map<SupplierViewModel>(supplier);
            return CreatedAtAction(nameof(GetSupplier), new { id = supplier.Id }, vm);
        }
    }
}
