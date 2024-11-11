﻿using PokemonReview.Data;
using PokemonReview.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoryExists(string name)
        {
            var category=_context.Categories.Where(c=> c.Name.Trim().ToLower() == name.Trim().ToLower()).FirstOrDefault();
            return category != null;
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);
           
            return Save();
        }

        public ICollection<Category> GetCategories()
        {
          return _context.Categories.OrderBy(c => c.Id).ToList();
        }

        public Category GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}