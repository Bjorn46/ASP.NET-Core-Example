using Assignment2.DTOs.Assignment2CDtos;
using Assignment2.Models;
using Assignment2.Services.Interfaces;

namespace Assignment2.Services
{
    public class AvailableDishService2C : IAvailableDishService2C
    {
        private readonly Assignment2Context _context;

        public AvailableDishService2C(Assignment2Context context)
        {
            _context = context;
        }

        public async Task<AvailableDishDto> AddAvailableDishAsync(CreateAvailableDishDto dishDto)
        {
            var availableDish = new AvailableDish
            {
                CookId = dishDto.CookId,
                Name = dishDto.Name,
                Price = dishDto.Price,
                Currency = dishDto.Currency,
                Quantity = dishDto.Quantity,
                AvailableFrom = dishDto.AvailableFrom,
                AvailableTo = dishDto.AvailableTo
            };

            _context.AvailableDishes.Add(availableDish);
            await _context.SaveChangesAsync();

            return new AvailableDishDto
            {
                DishId = availableDish.DishId,
                CookId = availableDish.CookId,
                Name = availableDish.Name,
                Price = availableDish.Price,
                Currency = availableDish.Currency,
                Quantity = availableDish.Quantity,
                AvailableFrom = availableDish.AvailableFrom,
                AvailableTo = availableDish.AvailableTo
            };
        }

        public async Task<bool> DeleteAvailableDishAsync(int dishId)
        {
            var dish = await _context.AvailableDishes.FindAsync(dishId);
            if (dish == null)
                return false;

            _context.AvailableDishes.Remove(dish);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<AvailableDishDto> GetAvailableDishByIdAsync(int dishId)
        {
            var dish = await _context.AvailableDishes.FindAsync(dishId);
            if (dish == null)
                return null;

            return new AvailableDishDto
            {
                DishId = dish.DishId,
                CookId = dish.CookId,
                Name = dish.Name,
                Price = dish.Price,
                Currency = dish.Currency,
                Quantity = dish.Quantity,
                AvailableFrom = dish.AvailableFrom,
                AvailableTo = dish.AvailableTo
            };
        }

        public async Task<bool> UpdateDishQuantityAsync(int dishId, int quantity)
        {
            var dish = await _context.AvailableDishes.FindAsync(dishId);
            if (dish == null)
                return false;

            dish.Quantity = quantity;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
