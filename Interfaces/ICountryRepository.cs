using PokemonReview.Models;

namespace PokemonReview.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        bool CountryExists(string name);
        bool CreateCountry(Country coutnry);
        bool Save();
    }
}
