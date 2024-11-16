using AutoMapper;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using PokemonReview.Dto.Category;
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


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] Create CategoryRequest)
        {
            if (CategoryRequest == null)
            {
                return BadRequest(ModelState);
            }
            var category = _categoryRepository.CategoryExists(CategoryRequest.Name);
            if (category)
            {
                ModelState.AddModelError("unique", "Category already exixt");
                return StatusCode(422, ModelState);
            }
            var categoryMap = _mapper.Map<Category>(CategoryRequest);
            _categoryRepository.CreateCategory(categoryMap);
            return Ok("success");
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetCategories() {
            var categories = _mapper.Map<List<Details>>(_categoryRepository.GetCategories());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(categories);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int id)
        {
            var category = _mapper.Map<Details>(_categoryRepository.GetCategory(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }
    }
}
