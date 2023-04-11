using Contracts;
using Entities.DataTransferObjects.Supplier;
using Entities.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [Route("api/supplier")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class SupplierController : Controller
    {
        private IRepositoryWrapper _repository;
        private readonly IConfiguration _configuration;

        public SupplierController(IRepositoryWrapper repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetAllSuppliers([FromQuery] PaginationParameters paginationParameters)
        {
            try 
            {
                var supplier = _repository.Supplier.GetSuppliers(paginationParameters);
                return Ok(supplier);
            } catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] SupplierForCreationDto supplierDto)
        {
            try
            {
                if(supplierDto == null)
                {
                    return BadRequest("Supplier is null");
                }
                if(!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var supplierEntity = supplierDto.Adapt<Supplier>();
                _repository.Supplier.CreateSupplier(supplierEntity);
                _repository.Save();

                return Ok(supplierEntity);
            } catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSupplierById(Guid id)
        {
            try
            {
                var supplier = _repository.Supplier.GetSupplierById(id);
                if(supplier == null)
                {
                    return NotFound();
                }

                return Ok(supplier);
            } catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] SupplierForUpdateDto supplierDto)
        {
            try
            {
                if (supplierDto == null)
                {
                    return BadRequest("Supplier is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var supplierEntity = supplierDto.Adapt<Supplier>();
                supplierEntity.Id = id;

                _repository.Supplier.UpdateSupplier(supplierEntity);
                _repository.Save();

                return Ok(supplierEntity);
            } catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var supplier = _repository.Supplier.GetSupplierById(id);
                if (supplier == null)
                {
                    return NotFound();
                }

                _repository.Supplier.DeleteSupplier(supplier);
                _repository.Save();

                return StatusCode(200);
            } catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
