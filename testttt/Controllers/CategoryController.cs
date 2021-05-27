using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using StreamingService.DTO;
using StreamingService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("AllCategories")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var category = await _categoryService.GetCategorysAsync();
            if (category == null)
            {
                return NotFound();
            }
            var categoryDTO = _mapper.Map<List<CategoryDTO>>(category);
            return Ok(categoryDTO);
        }

        [HttpGet("OneCategory")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int CategoryId)
        {
            var category = await _categoryService.GetCategoryAsync(CategoryId);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> CreateCategory(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _categoryService.AddCategoryAsync(category);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<CategoryDTO>> EditCategory(CategoryDTO categoryDTO)
        {
            var categoryToUpdate = _mapper.Map<Category>(categoryDTO);
            var updatedcategory = await _categoryService.UpdateCategoryAsync(categoryToUpdate);
            var categoryDTOTOReturn = _mapper.Map<CategoryDTO>(updatedcategory);
            return Ok(categoryDTOTOReturn);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok();
        }
    }
}
