using Assignment2.DTOs.AssignmentBQueries;

namespace Assignment2.Services.Interfaces
{
    // ICyclistService.cs
    public interface ICyclistService
    {
        Task<bool> CyclistExistsAsync(int cyclistId);
        Task<IEnumerable<CyclistMonthlyStatsDto>> GetCyclistMonthlyStatsAsync(int cyclistId);
    }
}
