using Assignment2.DTOs.AssignmentBQueries;
using Assignment2.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Assignment2.Services.Assignment2BServices
{

    // ICyclistService.cs
    public interface ICyclistService
    {
        Task<bool> CyclistExistsAsync(int cyclistId);
        Task<IEnumerable<CyclistMonthlyStatsDto>> GetCyclistMonthlyStatsAsync(int cyclistId);
    }
    public class CyclistSerivce : ICyclistService
    {
        Assignment2Context _context { get; set; }
        public CyclistSerivce(Assignment2Context context)
        {
            _context = context;
        }
        public async Task<bool> CyclistExistsAsync(int cyclistId)
        {
            return await _context.Cyclists.AnyAsync(c => c.CyclistId == cyclistId);
        }

        public async Task<IEnumerable<CyclistMonthlyStatsDto>> GetCyclistMonthlyStatsAsync(int cyclistId)
        {
            // Finding all trips for a cyclist 
            var trips = await _context.Trips
                .Include(x => x.Cyclist)
                .Include(x => x.Deliveries)
                .Where(x => x.CyclistId == cyclistId).ToListAsync();

            // Grouping by month
            var deliveriesGrouped = trips.GroupBy(x => x.Deliveries.First(y => y.DeliveryTime.HasValue).DeliveryTime.Value.Month).ToList();

            // Summing values based on months. 
            List<CyclistMonthlyStatsDto> result = new();
            foreach (var item in deliveriesGrouped)
            {
                var stat = new CyclistMonthlyStatsDto();
                stat.Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.Key);

                stat.TotalHours = item.Sum(x => x.CompletionTime.Value.ToTimeSpan().TotalMinutes) / 60;
                stat.TotalPrice = item.Sum(x => (double)x.Cyclist.HourlyRate * (x.CompletionTime.Value.ToTimeSpan().TotalMinutes / 60));
                result.Add(stat);
            }
            return result;
        }
    }
}
