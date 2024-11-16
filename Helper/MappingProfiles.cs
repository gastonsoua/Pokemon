using AutoMapper;
using PokemonReview.Dto;
using PokemonReview.Dto.Category;
using PokemonReview.Models;

namespace PokemonReview.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<Category, Details>();
            CreateMap<Category, Create>();
        }
    }
}
