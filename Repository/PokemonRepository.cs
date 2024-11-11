using PokemonReview.Data;
using PokemonReview.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;
        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var ownerEntity = _context.Owners.Where(O => O.Id == ownerId).FirstOrDefault();

            var category = _context.Categories.Where(c=>c.Id==categoryId).FirstOrDefault();
            var pokemonOwner = new PokemonOwner()
            {
                Owner = ownerEntity,
                Pokemon = pokemon,
                CreatedAt= DateTime.UtcNow, 
                UpdatedAt= DateTime.UtcNow,
            };
            
            _context.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategory()
            {
                Category = category,
                Pokemon= pokemon,
                CreatedAt= DateTime.UtcNow,
                UpdatedAt= DateTime.UtcNow
            };
            _context.Add(pokemonCategory);
            _context.Add(pokemon);
            return save();

        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemons.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemonByName(string name)
        {
            return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemons.OrderBy(p => p.Id).ToList();

        }

        public bool PokemonExists(int id)
        {
            return _context.Pokemons.Any(p => p.Id == id);  
        }

        public bool save()
        {
            var save = _context.SaveChanges();
            return save>0?true:false;
            throw new NotImplementedException();
        }
    }
}
