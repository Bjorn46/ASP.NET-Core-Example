using Assignment2.DTOs.Assignment2CDtos;

namespace Assignment2.Services.Interfaces
{
    public interface IAvailableDishService2C
    {
        Task<AvailableDishDto> AddAvailableDishAsync(CreateAvailableDishDto dishDto);
        Task<bool> UpdateDishQuantityAsync(int dishId, int quantity);
        Task<bool> DeleteAvailableDishAsync(int dishId);
        Task<AvailableDishDto> GetAvailableDishByIdAsync(int dishId);
    }
}
