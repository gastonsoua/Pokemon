using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReview.Interfaces;
using PokemonReview.Models;
using PokemonReview.Repository;
using PokemonReview.Dto.Country;

namespace PokemonReview.Controllers
{

    [Route("api/countries")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCountry([FromBody] CreateCountryDto CountryRequest)
        {
            if (CountryRequest == null)
            {
                return BadRequest(ModelState);
            }
            var country = _countryRepository.CountryExists(CountryRequest.Name);
            if (country)
            {
                ModelState.AddModelError("unique", "Country already exixt");
                return StatusCode(422, ModelState);
            }
            var countryMapped = _mapper.Map<Country>(CountryRequest);
            _countryRepository.CreateCountry(countryMapped);
            return Ok("Success");

        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetCountries()
        {
            var countries = _mapper.Map<List<DetailsCountryDto>>(_countryRepository.GetCountries());
            return Ok(countries);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetCountry(int id)
        {
            var country = _mapper.Map<DetailsCountryDto>(_countryRepository.GetCountry(id));
            if (country == null)
            {
                ModelState.AddModelError("response", "Country doesn't exist");
                return StatusCode(404, ModelState);
            }
            return Ok(country);
        }
    }
}
