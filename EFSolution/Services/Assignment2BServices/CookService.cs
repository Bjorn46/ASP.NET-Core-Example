using Assignment2.DTOs.AssignmentBQueries;
using Assignment2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Services.Assignment2BServices
{
    // ICookService.cs
    public interface ICookService
    {
        Task<IEnumerable<CookDto>> GetCooksAsync();
        Task<bool> CookExistsAsync(string cookId);
    }


    public class CookService : ICookService
    {
        Assignment2Context _context { get; set; }
        public CookService(Assignment2Context context)
        {
            _context = context;
        }
        public async Task<bool> CookExistsAsync(string cookId)
        {
            // Returning boolean if cook exist based on cookid 
            return await _context.Cooks.AnyAsync(x => x.CookId == cookId);
        }

        public async Task<IEnumerable<CookDto>> GetCooksAsync()
        {
            // Selecting all cooks, creating CookDTO based on selective properties
            var query = await _context.Cooks
                .Select(c => new CookDto
                {
                    Address = c.Address,
                    PhoneNumber = c.PhoneNumber,
                    CookId = c.CookId,
                    HasPassedFoodSafetyCourse = c.HasPassedFoodSafetyCourse
                })
                .ToListAsync();
            return query;
        }
    }
}
