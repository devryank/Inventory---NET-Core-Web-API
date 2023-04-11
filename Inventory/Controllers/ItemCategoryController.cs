using Contracts;
using Entities.DataTransferObjects.ItemCategory;
using Entities.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("api/category")]
    [Authorize(Roles = "Admin")]
    public class ItemCategoryController : Controller
    {
        private IRepositoryWrapper _repository;
        private readonly IConfiguration _configuration;

        public ItemCategoryController(IRepositoryWrapper repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetAllCategory([FromQuery] PaginationParameters paginationParameters)
        {
            try
            {
                var category = _repository.ItemCategory.GetAllItemCategory(paginationParameters);
                return Ok(category);
            } catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(Guid id) 
        {
            try
            {
                var category = _repository.ItemCategory.GetItemCategoryById(id);
                if(category == null)
                {
                    return NotFound();
                }

                return Ok(category);
            } catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}/items")]
        public IActionResult GetCategoryWithItems(Guid id) 
        {
            try
            {
                var category = _repository.ItemCategory.GetItemCategoryWithRelation(id);
                var categoryDto = category.Adapt<ItemCategoryWithRelationDto>();
                return Ok(categoryDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ItemCategoryForCreationDto categoryDto)
        {
            try
            {
                if (categoryDto == null)
                {
                    return BadRequest("Supplier is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var categoryEntity = categoryDto.Adapt<ItemCategory>();
                _repository.ItemCategory.CreateItemCategory(categoryEntity);
                _repository.Save();

                return Ok(categoryEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] ItemCategoryForUpdateDto categoryDto)
        {
            try
            {
                if (categoryDto == null)
                {
                    return BadRequest("Supplier is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var categoryEntity = categoryDto.Adapt<ItemCategory>();
                categoryEntity.Id = id;
                _repository.ItemCategory.UpdateItemCategory(categoryEntity);
                _repository.Save();

                return Ok(categoryEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var categoryEntity = _repository.ItemCategory.GetItemCategoryById(id);
            if(categoryEntity == null)
            {
                return NotFound();
            }

            _repository.ItemCategory.DeleteItemCategory(categoryEntity);
            _repository.Save();

            return Ok(200);
        }
    }
}
