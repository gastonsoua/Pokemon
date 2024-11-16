using System.Text.Json.Serialization;

namespace PokemonReview.Dto.Country
{
    public class CreateCountryDto
    {
        public required string Name { get; set; }
    }
}
