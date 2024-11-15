using Assignment2.DTOs.AssignmentBQueries;
using Assignment2.Models;
using Microsoft.EntityFrameworkCore;
using Assignment2.Services.Interfaces;

namespace Assignment2.Services
{
    public class AvailableDishService2B : IAvailableDishService2B
    {
        Assignment2Context _context { get; set; }
        public AvailableDishService2B(Assignment2Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AvailableDishesFromCookDto>> GetAvailableDishesByCookAsync(string cookId)
        {
            var availableDishes = await _context.AvailableDishes.Where(x => x.CookId == cookId).ToListAsync(); // Available dishes for a cook
            List<AvailableDishesFromCookDto> result = new();
            foreach (var availableDish in availableDishes)
            {
                // Creating DTOs 
                result.Add(new AvailableDishesFromCookDto()
                {
                    Name = availableDish.Name,
                    Price = availableDish.Price,
                    Currency = availableDish.Currency,
                    Quantity = availableDish.Quantity,
                    AvailableFrom = availableDish.AvailableFrom.ToString("dd/MM/yyyy HH:mm"), // Formatting to DDMMYYYY HHMM
                    AvailableTo = availableDish.AvailableTo.ToString("dd/MM/yyyy HH:mm")
                });
            }
            return result;
        }
    }
}
