using Assignment2.DTOs.AssignmentBQueries;

namespace Assignment2.Services.Interfaces
{
    // IReviewService.cs
    public interface IReviewService
    {
        Task<AverageRatingDto> GetAverageFoodRatingAsync(string cookId);
        Task<IEnumerable<CookRatingDto>> GetCooksRankedByRatingAsync();
    }
}
