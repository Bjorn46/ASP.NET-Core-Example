using Assignment2.DTOs.AssignmentBQueries;

namespace Assignment2.Services.Interfaces
{
    // ICookService.cs
    public interface ICookService
    {
        Task<IEnumerable<CookDto>> GetCooksAsync();
        Task<bool> CookExistsAsync(string cookId);
    }
}
