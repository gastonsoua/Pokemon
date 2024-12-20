﻿using PokemonReview.Data;
using PokemonReview.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        public CountryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CountryExists(string name)
        {
            var coutry = _context.Countries.Where(c => c.Name.Trim().ToLower() == name.Trim().ToLower()).FirstOrDefault();
            return coutry != null;
        }

        public bool CreateCountry(Country coutnry)
        {
            coutnry.CreatedAt = DateTime.Now;
            coutnry.UpdatedAt = DateTime.Now;
            _context.Add(coutnry);

            return Save();
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.OrderBy(c => c.Id).ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.FirstOrDefault(c => c.Id == id);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
