using Assignment2.DTOs.Authentication;
using Assignment2.Models;
using Microsoft.AspNetCore.Identity;

namespace Assignment2.Services
{
    public interface IAuthService
    {
        public Task<AuthResponseDto> RegisterAsync(RegisterUserDto model);
        public Task<AuthResponseDto> LoginAsync(LoginDto model);
    }
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtTokenService _jwtTokenService;
        public AuthService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
        }


        public async Task<AuthResponseDto> LoginAsync(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new AuthResponseDto
                {
                    Succeeded = false,
                    Errors = new[] { "Invalid credentials." }
                };
            }

            var result = await _signInManager.PasswordSignInAsync(user.Email, model.Password, false, false);
            if (result.Succeeded)
            {
                var token = await _jwtTokenService.GenerateJwtToken(user);
                return new AuthResponseDto
                {
                    Succeeded = true,
                    Token = token
                };
            }

            return new AuthResponseDto
            {
                Succeeded = false,
                Errors = new[] { "Invalid login attempt." }
            };

        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterUserDto model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                Name = $"{model.FirstName} {model.LastName}"
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var token = await _jwtTokenService.GenerateJwtToken(user);

                return new AuthResponseDto
                {
                    Succeeded = true,
                    Token = token
                };
            }

            return new AuthResponseDto
            {
                Succeeded = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }
    }
}
