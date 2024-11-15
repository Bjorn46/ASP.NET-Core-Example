using Assignment2.DTOs.AssignmentBQueries;
using Assignment2.Models;
using Assignment2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;
using Assignment2.Services.Interfaces;

namespace Assignment2.Controllers
{
    [ApiController]
    [Route("api/assignment2B")]
    public class Assignment2BQueries : ControllerBase
    {
        // Dependency injection. Services registered in program.cs 
        private readonly ICookService _cookService;
        private readonly IAvailableDishService2B _availableDishService;
        private readonly ICyclistService _cyclistService;
        private readonly IDeliveryService _deliveryService;
        private readonly IReviewService _reviewService;
        private readonly ITripService _tripService;

        public Assignment2BQueries(
            ICookService cookService,
            IAvailableDishService2B availableDishService,
            ICyclistService cyclistService,
            IDeliveryService deliveryService,
            IReviewService reviewService,
            ITripService tripService
            )
        {
            _cookService = cookService;
            _availableDishService = availableDishService;
            _cyclistService = cyclistService;
            _deliveryService = deliveryService;
            _reviewService = reviewService;
            _tripService = tripService;
        }


        /// <summary>
        /// Get the data collected for each cook.
        /// </summary>
        /// <returns>An action result</returns>
        [HttpGet("Query1", Name = "Query 1")]
        [ProducesResponseType(typeof(IEnumerable<CookDto>), StatusCodes.Status200OK)] 
        public async Task<IActionResult> Query1()
        {
            return Ok(await _cookService.GetCooksAsync());
        }


        /// <summary>
        /// Available portion name, quantity, price, and time interval for a Kitchen.
        /// </summary>
        /// <returns>An action result</returns>
        [HttpGet("Query2", Name = "Query 2")]
        [ProducesResponseType(typeof(IEnumerable<AvailableDishesFromCookDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Query2([FromQuery] string cookId)
        {
            if (string.IsNullOrWhiteSpace(cookId))
                return BadRequest("Cook ID cannot be null or empty.");

            if (await _cookService.CookExistsAsync(cookId))
                return Ok(await _availableDishService.GetAvailableDishesByCookAsync(cookId));
            else return NotFound($"No cook with id: {cookId}");
        }


        /// <summary>
        /// Get the list of goods and the provider kitchen in an order
        /// </summary>
        /// <param name="id">Delivery ID</param>
        /// <returns>An action result</returns>
        [HttpGet("Query3", Name = "Query 3")]
        [ProducesResponseType(typeof(IEnumerable<DeliveryDishDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Query3([FromQuery] int id)
        {
            if (await _deliveryService.DeliveryExists(id))
                return Ok(await _deliveryService.GetDeliveryDishesAsync(id));
            else return NotFound($"No orders found with the Delivery ID: {id}");
        }


        /// <summary>
        /// Get the route for a trip including pickups and deliveries.
        /// </summary>
        /// <param name="tripId">Trip ID</param>
        /// <returns>An action result</returns>
        [HttpGet("Query4", Name = "Query 4")]
        [ProducesResponseType(typeof(IEnumerable<RouteDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Query4([FromQuery] int tripId)
        {
            
            if (await _tripService.TripExistsAsync(tripId))
                return Ok(await _tripService.GetTripRouteAsync(tripId));
            else return NotFound($"No trip found with Trip ID: {tripId}");
        }



        /// <summary>
        /// Get the average food rating for a specific cook.
        /// </summary>
        /// <param name="cookId">Cook ID</param>
        /// <returns>An action result</returns>
        [HttpGet("Query5", Name = "Query 5")]
        [ProducesResponseType(typeof(AverageRatingDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Query5([FromQuery] string cookId)
        {
            if (string.IsNullOrWhiteSpace(cookId))
                return BadRequest("Cook ID cannot be null or empty.");

            if (await _cookService.CookExistsAsync(cookId))
                return Ok(await _reviewService.GetAverageFoodRatingAsync(cookId));
            else return NotFound($"No cook found with ID: {cookId}");
        }

        /// <summary>
        /// Get total hours worked and total pay per month for a cyclist.
        /// </summary>
        /// <param name="cyclistId">Cyclist ID</param>
        /// <returns>An action result</returns>
        [HttpGet("Query6", Name = "Query 6")]
        [ProducesResponseType(typeof(IEnumerable<CyclistMonthlyStatsDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Query6([FromQuery] int cyclistId)
        {
            if (await _cyclistService.CyclistExistsAsync(cyclistId))
                return Ok(await _cyclistService.GetCyclistMonthlyStatsAsync(cyclistId));
            else return NotFound($"No cyclist found with Cyclist ID: {cyclistId}");
        }


        /// <summary>
        /// Get all cooks ranked by their average review ratings.
        /// </summary>
        /// <returns>An action result</returns>
        [HttpGet("Query7", Name = "Query 7")]
        [ProducesResponseType(typeof(IEnumerable<CookRatingDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Query7()
        {
            return Ok(await _reviewService.GetCooksRankedByRatingAsync());
        }

    }
}
