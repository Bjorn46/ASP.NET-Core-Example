using Assignment2.DTOs.Assignment2CDtos;
using Assignment2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [ApiController]
    [Route("api/assignment2C")]
    public class Assignment2C_CRUD : ControllerBase
    {
        // Dependency injection. Services registered in program.
        private readonly IAvailableDishService2C _availableDishService;
        private readonly ILogger<Assignment2C_CRUD> _logger;

        public Assignment2C_CRUD(IAvailableDishService2C availableDishService, ILogger<Assignment2C_CRUD> logger)
        {
            // Constructor Dependency Injection.
            _availableDishService = availableDishService;
            _logger = logger;
        }

        /// <summary>
        /// Add a new dish.
        /// </summary>
        [HttpPost(Name = "Create a new dish")]
        [ProducesResponseType(typeof(AvailableDishDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddDish([FromBody] CreateAvailableDishDto dishDto)
        {
            _logger.LogInformation("POST request received.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdDish = await _availableDishService.AddAvailableDishAsync(dishDto);

            return CreatedAtAction(nameof(GetDishById), new { id = createdDish.DishId }, createdDish);
        }

        /// <summary>
        /// Get a dish by ID.
        /// </summary>
        [HttpGet("{id}", Name = "Get dish by id")]
        [ProducesResponseType(typeof(AvailableDishDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDishById(int id)
        {
            _logger.LogInformation("GET by id request received.");
            var dish = await _availableDishService.GetAvailableDishByIdAsync(id);

            if (dish == null)
                return NotFound($"No dish found with ID: {id}");

            return Ok(dish);
        }

        /// <summary>
        /// Update the quantity of a dish.
        /// </summary>
        [HttpPut("{id}/quantity", Name = "Update dish quantity")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateDishQuantity(int id, [FromBody] UpdateQuantityDto updateDto)
        {
            _logger.LogInformation("PUT request received.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _availableDishService.UpdateDishQuantityAsync(id, updateDto.Quantity);

        if (!result)
            return NotFound($"No dish found with ID: {id}");

        return NoContent();
        }

        /// <summary>
        /// Delete a dish.
        /// </summary>
        [HttpDelete("{id}", Name = "Delete dish by id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteDish(int id)
        {
            _logger.LogInformation("DELETE request received.");
            var result = await _availableDishService.DeleteAvailableDishAsync(id);

            if (!result)
                return NotFound($"No dish found with ID: {id}");

            return NoContent();
        }


    }

}
