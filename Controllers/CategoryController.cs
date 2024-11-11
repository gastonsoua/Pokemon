using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using PokemonReview.Dto;
using PokemonReview.Interfaces;
using PokemonReview.Models;
using PokemonReview.Repository;
using System.Collections;

namespace PokemonReview.Controllers
{
  
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetCategories() {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(categories);
        }

        [HttpPost] 
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] Category CategoryRequest)
        {
            if  (CategoryRequest == null)
            {
                  return BadRequest(ModelState);
            }
            CategoryRequest.CreatedAt = DateTime.UtcNow;
            CategoryRequest.UpdatedAt = DateTime.UtcNow;
            var category= _categoryRepository.CategoryExists(CategoryRequest.Name);
            if (category) {
                ModelState.AddModelError("unique", "Category already exixt");
            return StatusCode(422, ModelState);
            }
            var categoryMap = _mapper.Map<Category>(CategoryRequest);
            _categoryRepository.CreateCategory(categoryMap);
            return Ok("success");
        }
    }
}
