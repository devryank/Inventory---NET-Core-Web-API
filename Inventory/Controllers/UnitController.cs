using Contracts;
using Entities.DataTransferObjects.Unit;
using Entities.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [Route("api/unit")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class UnitController : Controller
    {
        private IRepositoryWrapper _repository;
        private readonly IConfiguration _configuration;
        public UnitController(IRepositoryWrapper repository, IConfiguration configuration) 
        {
            _repository = repository;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetAllUnit([FromQuery] PaginationParameters paginationParameters)
        {
            try
            {
                var unit = _repository.Unit.GetAllUnit(paginationParameters);
                return Ok(unit);
            } catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUnitById(Guid id)
        {
            try
            {
                var unit = _repository.Unit.GetUnitById(id);
                if(unit == null) 
                {
                    return NotFound();
                }

                return Ok(unit);
            } catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] UnitForCreationDto unitDto)
        {
            try
            {
                if(unitDto == null)
                {
                    return BadRequest("Unit is null");
                }
                if(!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var unitEntity = unitDto.Adapt<Unit>();
                _repository.Unit.CreateUnit(unitEntity);
                _repository.Save();

                return Ok(unitEntity);
            } catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, UnitForUpdateDto unitDto)
        {
            try
            {
                if (unitDto == null)
                {
                    return BadRequest("Unit is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var unitEntity = unitDto.Adapt<Unit>();
                unitEntity.Id = id;

                _repository.Unit.UpdateUnit(unitEntity);
                _repository.Save();

                return Ok(unitEntity);
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
                var unit = _repository.Unit.GetUnitById(id);
                if(unit == null)
                {
                    return NotFound();
                }

                _repository.Unit.DeleteUnit(unit);
                _repository.Save();

                return StatusCode(200);
            } catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
