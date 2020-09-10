﻿using Microsoft.EntityFrameworkCore;
using MyDishesApp.Repository.Data;
using MyDishesApp.Repository.Data.Entities;
using System;
using System.Threading.Tasks;

namespace MyDishesApp.Repository.Services
{
    /// <inheritdoc />
    public class DishRepository : IDishRepository
    {
        private readonly DishesContext _context;

        /// <summary>
        /// Constructor with the dishes context
        /// </summary>
        /// <param name="context">The dishes context</param>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="context"/> is null</exception>
        public DishRepository(DishesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> DishExists(int dishId)
        {
            return await _context.Dishes.AnyAsync(d => d.DishId == dishId);
        }

        /// <inheritdoc />
        //public async Task<IEnumerable<Dish>> GetDishesAsync()
        //{
        //    return await _context.Dishes.Include(i => i.Ingredients)
        //        .OrderBy(d => d.Name).ToListAsync();
        //}

        //public async Task<Dish> GetDishAsync(int dishId)
        //{
        //    return await _context.Dishes.Include(i => i.Ingredients)
        //        .Where(d => d.DishId == dishId).FirstOrDefaultAsync();
        //}

        public async Task AddDishAsync(Dish dish)
        {
            await _context.Dishes.AddAsync(dish);
        }

        public void DeleteDish(Dish dish)
        {
            _context.Dishes.Remove(dish);
        }

        /// <inheritdoc />
        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
