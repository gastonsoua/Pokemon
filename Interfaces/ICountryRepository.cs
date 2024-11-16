using PokemonReview.Models;

namespace PokemonReview.Interfaces
{
    public interface ICountryRepository
    {
        bool CountryExists(string name);
        bool CreateCountry(Country coutnry);
        bool Save();
    }
}
