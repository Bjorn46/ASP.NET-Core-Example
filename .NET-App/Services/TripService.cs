using Assignment2.DTOs.AssignmentBQueries;
using Assignment2.Models;
using Microsoft.EntityFrameworkCore;
using Assignment2.Services.Interfaces;

namespace Assignment2.Services
{
    public class TripService : ITripService
    {
        Assignment2Context _context { get; set; }
        public TripService(Assignment2Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RouteDto>> GetTripRouteAsync(int tripId)
        {
            var trip = await _context.Trips
                .Include(x => x.Deliveries) // Include related Deliveries for the trip
                    .ThenInclude(x => x.Customer) // For each Delivery, include associated Customer
                .Include(x => x.Deliveries)
                    .ThenInclude(x => x.DishOrders) // For each Delivery, include associated DishOrders
                        .ThenInclude(x => x.Dish) // Include each Dish in the DishOrders
                            .ThenInclude(x => x.Cook) // Include the Cook associated with each Dish
                .FirstAsync(x => x.TripId == tripId); // Find the specific trip by tripId


            var pickups = trip.Deliveries
                .SelectMany(d => d.DishOrders) // Select all DishOrders in each Delivery
                .GroupBy(dOrder => new { dOrder.Dish.Cook.Address, dOrder.OrderDate }) // Group by Cook's address and OrderDate
                .Select(g => new RouteDto
                {
                    Address = g.Key.Address, // The Cook's address
                    Time = g.Key.OrderDate.TimeOfDay, // Time of the order
                    Type = "Pickup" // Label this as a "Pickup"
                });

            var deliveries = trip.Deliveries
                .Select(d => new RouteDto
                {
                    Address = d.Customer.Address, // The Customer's address
                    Time = d.DeliveryTime.HasValue ? d.DeliveryTime.Value.TimeOfDay : null, // Delivery time if available
                    Type = "Delivery" // Label this as a "Delivery"
                });

            // Combine pickups and deliveries into a single ordered route list
            var routePoints = pickups.Concat(deliveries)
                .OrderBy(rp => rp.Time.HasValue ? rp.Time.Value : TimeSpan.MaxValue) // Sort by time, handling nulls as max value
                .ToList();

            return routePoints;
        }

        public async Task<bool> TripExistsAsync(int tripId)
        {
            return await _context.Trips.AnyAsync(t => t.TripId == tripId);
        }
    }
}
