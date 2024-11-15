using Assignment2.DTOs.AssignmentBQueries;

namespace Assignment2.Services.Interfaces
{
    // IDeliveryService.cs
    public interface IDeliveryService
    {
        Task<IEnumerable<DeliveryDishDTO>> GetDeliveryDishesAsync(int deliveryId);
        Task<bool> DeliveryExists(int deliveryId);
    }
}
