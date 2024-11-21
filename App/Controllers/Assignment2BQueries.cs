using Assignment2.DTOs.AssignmentBQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;
using Assignment2.Services.Interfaces;

namespace Assignment2.Controllers
{
    [ApiController]
    [Route("api/assignment2B")]
    [Authorize]
    public class Assignment2BQueries : ControllerBase
    {
        // Dependency injection. Services registered in program.cs 
        private readonly ICookService _cookService;
        private readonly IAvailableDishService2B _availableDishService;
        private readonly ICyclistService _cyclistService;
        private readonly IDeliveryService _deliveryService;
        private readonly IReviewService _reviewService;
        private readonly ITripService _tripService;
        private readonly ILogger<Assignment2BQueries> _logger;

        public Assignment2BQueries(
            ICookService cookService,
            IAvailableDishService2B availableDishService,
            ICyclistService cyclistService,
            IDeliveryService deliveryService,
            IReviewService reviewService,
            ITripService tripService,
            ILogger<Assignment2BQueries> logger

            )
        {
            _cookService = cookService;
            _availableDishService = availableDishService;
            _cyclistService = cyclistService;
            _deliveryService = deliveryService;
            _reviewService = reviewService;
            _tripService = tripService;
            _logger = logger;
        }


        /// <summary>
        /// Get the data collected for each cook.
        /// </summary>
        /// <returns>An action result</returns>
        [HttpGet("Query1", Name = "Query 1")]
        [ProducesResponseType(typeof(IEnumerable<CookDto>), StatusCodes.Status200OK)]
        [Authorize(Roles = "Admin,Manager")] // Admins and Managers can access all cook data
        public async Task<IActionResult> Query1()
        {
            _logger.LogInformation("Query1: Getting data for all cooks.");
            return Ok(await _cookService.GetCooksAsync());
        }


        /// <summary>
        /// Available portion name, quantity, price, and time interval for a Kitchen.
        /// </summary>
        /// <returns>An action result</returns>
        [HttpGet("Query2", Name = "Query 2")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<AvailableDishesFromCookDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Query2([FromQuery] string cookId)
        {
            _logger.LogInformation("Query2: Getting available dishes for cook with ID {CookId}.", cookId);

            if (string.IsNullOrWhiteSpace(cookId)) {
                _logger.LogWarning("Query2: Cook ID is null or empty.");
                return BadRequest("Cook ID cannot be null or empty.");
        }
            if (await _cookService.CookExistsAsync(cookId))
            {
                return Ok(await _availableDishService.GetAvailableDishesByCookAsync(cookId));
            }
            else
            {
                _logger.LogWarning("Query2: No cook found with ID {CookId}.", cookId);
                return NotFound($"No cook with id: {cookId}");
            }
        }


        /// <summary>
        /// Get the list of goods and the provider kitchen in an order
        /// </summary>
        /// <param name="id">Delivery ID</param>
        /// <returns>An action result</returns>
        [HttpGet("Query3", Name = "Query 3")]
        [Authorize(Roles = "Admin")] 
        [ProducesResponseType(typeof(IEnumerable<DeliveryDishDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Query3([FromQuery] int id)
        {
            _logger.LogInformation("Query3: Getting delivery dishes for delivery ID {DeliveryId}.", id);

            if (await _deliveryService.DeliveryExists(id))
                return Ok(await _deliveryService.GetDeliveryDishesAsync(id));
            else
            {
                _logger.LogWarning("Query3: No orders found with the Delivery ID {DeliveryId}.", id);
                return NotFound($"No orders found with the Delivery ID: {id}");
            }
        }


        /// <summary>
        /// Get the route for a trip including pickups and deliveries.
        /// </summary>
        /// <param name="tripId">Trip ID</param>
        /// <returns>An action result</returns>
        [HttpGet("Query4", Name = "Query 4")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IEnumerable<RouteDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Query4([FromQuery] int tripId)
        {
            _logger.LogInformation("Query4: Getting trip route for trip ID {TripId}.", tripId);

            if (await _tripService.TripExistsAsync(tripId))
                return Ok(await _tripService.GetTripRouteAsync(tripId));

            else
            {
                _logger.LogWarning("Query4: No trip found with Trip ID {TripId}.", tripId);
                return NotFound($"No trip found with Trip ID: {tripId}");
            }
        }



        /// <summary>
        /// Get the average food rating for a specific cook.
        /// </summary>
        /// <param name="cookId">Cook ID</param>
        /// <returns>An action result</returns>
        [HttpGet("Query5", Name = "Query 5")]
        [Authorize(Roles = "Admin,Cook")] 
        [ProducesResponseType(typeof(AverageRatingDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Query5([FromQuery] string cookId)
        {
            _logger.LogInformation("Query5: Getting average food rating for cook ID {CookId}.", cookId);

            if (string.IsNullOrWhiteSpace(cookId))
            {
                _logger.LogWarning("Query5: Cook ID is null or empty.");
                return BadRequest("Cook ID cannot be null or empty.");
            }

            if (User.IsInRole("Cook"))
            {
                var userCookId = User.FindFirst("cookId")?.Value;
                if (userCookId != cookId) { 
                    return Forbid("User can only access own values");
                }
            }

            if (await _cookService.CookExistsAsync(cookId))
                return Ok(await _reviewService.GetAverageFoodRatingAsync(cookId));
            else
            {
                _logger.LogWarning("Query5: No cook found with ID {CookId}.", cookId);
                return NotFound($"No cook found with ID: {cookId}");
            }
        }

        /// <summary>
        /// Get total hours worked and total pay per month for a cyclist.
        /// </summary>
        /// <param name="cyclistId">Cyclist ID</param>
        /// <returns>An action result</returns>
        [HttpGet("Query6", Name = "Query 6")]
        [Authorize(Roles = "Admin,Cyclist")] 
        [ProducesResponseType(typeof(IEnumerable<CyclistMonthlyStatsDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Query6([FromQuery] int cyclistId)
        {

            if (User.IsInRole("Cyclist"))
            {
                var userCyclistId = User.FindFirst("CyclistId")?.Value;
                _logger.LogInformation("Query6: Getting monthly stats for cyclist ID {CyclistId}.", cyclistId);
                if (!int.TryParse(userCyclistId, out int userCyclistIdInt) || userCyclistIdInt != cyclistId) { 
                    return Forbid("You can only access own statistics");
                    }
            }

            if (await _cyclistService.CyclistExistsAsync(cyclistId)) { 
                return Ok(await _cyclistService.GetCyclistMonthlyStatsAsync(cyclistId));
                }
                else
                {
                    _logger.LogWarning("Query6: No cyclist found with Cyclist ID {CyclistId}.", cyclistId);
                    return NotFound($"No cyclist found with Cyclist ID: {cyclistId}");
                }
        }


        /// <summary>
        /// Get all cooks ranked by their average review ratings.
        /// </summary>
        /// <returns>An action result</returns>
        [HttpGet("Query7", Name = "Query 7")]
        [Authorize(Roles = "Admin,Customer")] // Admin and Customer can see cook rankings
        [ProducesResponseType(typeof(IEnumerable<CookRatingDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Query7()
        {
            _logger.LogInformation("Query7: Getting all cooks ranked by their average review ratings.");
            return Ok(await _reviewService.GetCooksRankedByRatingAsync());
        }

    }
}
