using Assignment2.DTOs.AssignmentBQueries;

namespace Assignment2.Services.Interfaces
{
    // IAvailableDishService.cs
    public interface IAvailableDishService2B
    {
        Task<IEnumerable<AvailableDishesFromCookDto>> GetAvailableDishesByCookAsync(string cookId);
    }
}
