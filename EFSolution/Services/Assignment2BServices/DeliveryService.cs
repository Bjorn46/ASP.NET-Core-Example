using Assignment2.DTOs.AssignmentBQueries;
using Assignment2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Services.Assignment2BServices
{
    // IDeliveryService.cs
    public interface IDeliveryService
    {
        Task<IEnumerable<DeliveryDishDTO>> GetDeliveryDishesAsync(int deliveryId);
        Task<bool> DeliveryExists(int deliveryId);
    }
    public class DeliveryService : IDeliveryService
    {
        Assignment2Context _context { get; set; }
        public DeliveryService(Assignment2Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DeliveryDishDTO>> GetDeliveryDishesAsync(int deliveryId)
        {

            var dishOrders = _context.DishOrders;
            var availableDishes = _context.AvailableDishes;
            var cooks = _context.Cooks;

            var queryResult = await _context.Deliveries
            .Where(d => d.Id == deliveryId) // Filtering for the specific delivery by its ID
            .Join(_context.DishOrders,
                    delivery => delivery.Id,
                    dishOrder => dishOrder.Delivery,
                    (delivery, dishOrder) => new { Delivery = delivery, DishOrder = dishOrder }) // Joining deliveries with related dish orders
            .Join(
                    _context.AvailableDishes,
                    dishId => dishId.DishOrder.DishId,
                    availableDish => availableDish.DishId,
                    (temp, availableDish) => new { temp.Delivery, temp.DishOrder, AvailableDish = availableDish }) // Joining to get details of each dish in the delivery
            .Join(
                _context.Cooks,
                cookId => cookId.AvailableDish.CookId,
                cook => cook.CookId,
                (temp, cook) => new DeliveryDishDTO
                {
                    Name = temp.AvailableDish.Name, // Name of the dish from AvailableDishes
                    Quantity = temp.DishOrder.Quantity, // Quantity ordered from DishOrders
                    CookName = cook.Name // Name of the cook associated with the dish
                }).ToListAsync();

            return queryResult;
        }

        public async Task<bool> DeliveryExists(int deliveryId)
        {
            return await _context.Deliveries.AnyAsync(x => x.Id == deliveryId);
        }
    }
}
