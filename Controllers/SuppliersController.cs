using Microsoft.AspNetCore.Mvc;
using warehouse.Api.Models;

[ApiController]
    [Route("api/suppliers")]
    public class SuppliersController : ControllerBase
    {
        private readonly SupplierService supplierService;

        public SuppliersController(SupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        [HttpGet]
        public ActionResult<List<Supplier>> GetAll()
        {
            return Ok(supplierService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Supplier> GetById([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid supplier id");
            }

            var supplier = supplierService.GetById(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return Ok(supplier);
        }

        [HttpPost]
        public ActionResult<Supplier> Create(CreateSupplierRequest request)
        {
            var supplier = supplierService.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = supplier.Id }, supplier);
        }

        [HttpDelete("{id}")]
        public ActionResult Deactivate(Guid id)
        {
            if (!supplierService.Deactivate(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
