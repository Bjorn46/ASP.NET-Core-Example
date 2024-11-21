using Assignment2.DTOs.Authentication;
using Assignment2.Models;
using Assignment2.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Assignment2.Controllers
{
    public class AuthenticationController : ControllerBase 
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(
            IAuthService authService,
            ILogger<AuthenticationController> logger)
        {
            _logger = logger;
            _authService = authService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(model);
            if (result.Succeeded) 
            {
                _logger.LogInformation("Register: Successfully registered user with email {Email}.", model.Email);
                return Ok(result);
            }

            _logger.LogWarning("Register: Failed to register user with email {Email}. Errors: {Errors}", model.Email, string.Join(", ", result.Errors));
            return BadRequest(result);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var result = await _authService.LoginAsync(model);
            if (result.Succeeded) 
            {
                _logger.LogInformation("Login: User logged in with email {Email}.", model.Email);
                return Ok(result);
            }

            _logger.LogWarning("Login: User with {Email} failed to login. Errors: {Errors}", model.Email, string.Join(", ", result.Errors));
            return BadRequest(result);
        }

    }

}
