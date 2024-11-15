using Assignment2.DTOs.AssignmentBQueries;

namespace Assignment2.Services.Interfaces
{
    // ITripService.cs
    public interface ITripService
    {
        Task<bool> TripExistsAsync(int tripId);
        Task<IEnumerable<RouteDto>> GetTripRouteAsync(int tripId);
    }
}
