using AutoMapper;
using PokemonReview.Dto;
using PokemonReview.Models;
using PokemonReview.Dto.Country;
using PokemonReview.Dto.Category;

namespace PokemonReview.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<Category, DetailsCategoryDto>();
            CreateMap<CreateCategoryDto,Category >();
            CreateMap<CreateCountryDto,Country>();
        }
    }
}
