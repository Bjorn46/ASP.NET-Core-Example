using Assignment2.DTOs.AssignmentBQueries;
using Assignment2.Models;
using Microsoft.EntityFrameworkCore;
using Assignment2.Services.Interfaces;

namespace Assignment2.Services
{
    public class ReviewService : IReviewService
    {
        Assignment2Context _context { get; set; }
        public ReviewService(Assignment2Context context)
        {
            _context = context;
        }
        public async Task<AverageRatingDto> GetAverageFoodRatingAsync(string cookId)
        {
            double? averageRating = await _context.Reviews.Where(x => x.Order.Dish.Cook.CookId == cookId).Select(x => x.FoodRating).AverageAsync();

            return new AverageRatingDto { Average_Rating = averageRating ?? 0 };

        }

        public async Task<IEnumerable<CookRatingDto>> GetCooksRankedByRatingAsync()
        {
            return await _context.Reviews
                .Where(x => x.FoodRating.HasValue)
                .GroupBy(x => x.Order.Dish.Cook.Name)
                .Select(x =>
                    new CookRatingDto()
                    {
                        AverageRating = x.Average(y => y.FoodRating.Value),
                        CookName = x.Key
                    })
                .OrderByDescending(x => x.AverageRating)
                .ToListAsync();
        }
    }
}
