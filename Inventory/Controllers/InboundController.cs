using Contracts;
using Entities.DataTransferObjects.InAndOutbound;
using Entities.DataTransferObjects.Item;
using Entities.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("api/inbound")]
    [Authorize(Roles = "Admin")]
    public class InboundController : Controller
    {
        private IRepositoryWrapper _repository;
        private readonly IConfiguration _configuration;
        public InboundController(IRepositoryWrapper repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] PaginationParameters paginationParameters)
        {
            try
            {
                var inbounds = _repository.Inbound.GetAllInbound(paginationParameters);

                var inboundsArray = new List<InAndOutboundWithRelationDto>();
                foreach (var row in inbounds)
                {
                    var newRow = row.Adapt<InAndOutboundWithRelationDto>();
                    inboundsArray.Add(newRow);
                }
                return Ok(inboundsArray);
            } catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetInboundById(Guid id)
        {
            try
            {
                var inbound = _repository.Inbound.GetInboundById(id);
                return Ok(inbound);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetInBoundWithDetail(Guid id)
        {
            try
            {
                var inbound = _repository.Inbound.GetInboundWithRelation(id);
                var inboundEntity = inbound.Adapt<InAndOutboundWithRelationDto>();
                return Ok(inboundEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] InAndOutboundForCreationDto inboundDto)
        {
            try
            {
                if(inboundDto == null)
                {
                    return BadRequest("inbound is null");
                }
                if(!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                inboundDto.Date = DateTime.Now;
                inboundDto.Total = inboundDto.Qty * inboundDto.Price;

                var itemEntity = _repository.Item.GetItemByCode(inboundDto.Code);
                itemEntity.Stock += inboundDto.Qty;
                var inboundEntity = inboundDto.Adapt<Inbound>();
                _repository.Inbound.CreateInbound(inboundEntity);
                _repository.Item.UpdateItem(itemEntity);
                _repository.Save();
                return Ok(200);
            } 
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] InAndOutboundForUpdateDto inboundDto)
        {
            try
            {
                if (inboundDto == null)
                {
                    return BadRequest("inbound is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                inboundDto.Date = DateTime.Now;
                inboundDto.Total = inboundDto.Qty * inboundDto.Price;

                var itemEntity = _repository.Item.GetItemByCode(inboundDto.Code);
                var inboundSource = _repository.Inbound.GetInboundById(id);
                var inboundEntity = inboundDto.Adapt<Inbound>();

                inboundEntity.Id = id;
                itemEntity.Stock += inboundEntity.Qty - inboundSource.Qty;

                _repository.Inbound.UpdateInbound(inboundEntity);
                _repository.Item.UpdateItem(itemEntity);
                _repository.Save();

                return Ok(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var inboundEntity = _repository.Inbound.GetInboundById(id);
            var itemEntity = _repository.Item.GetItemByCode(inboundEntity.Code);
            itemEntity.Stock -= inboundEntity.Qty;

            if (inboundEntity == null)
            {
                return NotFound();
            }

            _repository.Item.UpdateItem(itemEntity);
            _repository.Inbound.DeleteInbound(inboundEntity);
            _repository.Save();

            return StatusCode(200);
        }
    }
}
