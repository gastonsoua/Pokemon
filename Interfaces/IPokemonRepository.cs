using PokemonReview.Models;

namespace PokemonReview.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemonByName(string name);
        bool PokemonExists(int id);
        bool CreatePokemon(int ownerId, int categoryId,Pokemon pokemon);
        bool save();
    }
}
