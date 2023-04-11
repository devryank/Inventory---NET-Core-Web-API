using Contracts;
using Entities.DataTransferObjects.Item;
using Entities.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("api/item")]
    [Authorize(Roles = "Admin")]
    public class ItemController : Controller
    {
        private IRepositoryWrapper _repository;
        private readonly IConfiguration _configuration;

        public ItemController(IRepositoryWrapper repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetAllItems([FromQuery] PaginationParameters paginationParameters)
        {
            try
            {
                var items = _repository.Item.GetAllItem(paginationParameters);
                var itemsArray = new List<ItemWithRelationDto>();
                foreach(var row in items)
                {
                    var newRow = row.Adapt<ItemWithRelationDto>();
                    itemsArray.Add(newRow);
                }
                return Ok(itemsArray);
            } catch(Exception ex)
            {
                return StatusCode(500, ex);
            }   
        }

        [HttpGet("{code}")]
        public IActionResult GetItemById(string code)
        {
            try
            {
                var item = _repository.Item.GetItemByCode(code);
                if(item == null)
                {
                    return NotFound();
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{code}/detail")]
        public IActionResult GetItemWithRelation(string code)
        {
            try
            {
                var item = _repository.Item.GetItemWithRelation(code);
                if (item == null)
                {
                    return NotFound();
                }
                var itemDto = item.Adapt<ItemWithRelationDto>();
                return Ok(itemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public IActionResult Create([FromForm] ItemForCreationDto itemDto, [FromForm(Name = "Photo")] IFormFile file)
        {
            itemDto.Code = "SKU-" + new Random().Next(1000,2000);
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                itemDto.Photo = ms.ToArray();
            }
            try
            {
                if (itemDto == null)
                {
                    return BadRequest("Unit is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                var itemEntity = itemDto.Adapt<Item>();
                _repository.Item.CreateItem(itemEntity);
                _repository.Save();

                return Ok(itemEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
