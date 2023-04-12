using Contracts;
using Entities.DataTransferObjects.InAndOutbound;
using Entities.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("api/outbound")]
    [Authorize(Roles = "Admin")]
    public class OutboundController : Controller
    {
        private IRepositoryWrapper _repository;
        private readonly IConfiguration _configuration;
        public OutboundController(IRepositoryWrapper repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] PaginationParameters paginationParameters)
        {
            try
            {
                var outbounds = _repository.Outbound.GetAllOutbound(paginationParameters);

                var outboundsArray = new List<InAndOutboundWithRelationDto>();
                foreach (var row in outbounds)
                {
                    var newRow = row.Adapt<InAndOutboundWithRelationDto>();
                    outboundsArray.Add(newRow);
                }
                return Ok(outboundsArray);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOutboundById(Guid id)
        {
            try
            {
                var outbound = _repository.Outbound.GetOutboundById(id);
                return Ok(outbound);
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
                var outbound = _repository.Outbound.GetOutboundWithRelation(id);
                var outboundEntity = outbound.Adapt<InAndOutboundWithRelationDto>();
                return Ok(outboundEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] InAndOutboundForCreationDto outboundDto)
        {
            try
            {
                if (outboundDto == null)
                {
                    return BadRequest("outbound is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                outboundDto.Date = DateTime.Now;
                outboundDto.Total = outboundDto.Qty * outboundDto.Price;

                var itemEntity = _repository.Item.GetItemByCode(outboundDto.Code);
                itemEntity.Stock -= outboundDto.Qty;
                var outboundEntity = outboundDto.Adapt<Outbound>();
                _repository.Outbound.CreateOutbound(outboundEntity);
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
        public IActionResult Update(Guid id, [FromBody] InAndOutboundForUpdateDto outboundDto)
        {
            try
            {
                if (outboundDto == null)
                {
                    return BadRequest("outbound is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                outboundDto.Date = DateTime.Now;
                outboundDto.Total = outboundDto.Qty * outboundDto.Price;

                var itemEntity = _repository.Item.GetItemByCode(outboundDto.Code);
                var outboundSource = _repository.Outbound.GetOutboundById(id);
                var outboundEntity = outboundDto.Adapt<Outbound>();

                outboundEntity.Id = id;
                itemEntity.Stock -= outboundEntity.Qty - outboundSource.Qty;

                _repository.Outbound.UpdateOutbound(outboundEntity);
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
            var outboundEntity = _repository.Outbound.GetOutboundById(id);
            var itemEntity = _repository.Item.GetItemByCode(outboundEntity.Code);
            itemEntity.Stock += outboundEntity.Qty;

            if (outboundEntity == null)
            {
                return NotFound();
            }

            _repository.Item.UpdateItem(itemEntity);
            _repository.Outbound.DeleteOutbound(outboundEntity);
            _repository.Save();

            return StatusCode(200);
        }
    }
}
