using DEP.Repository.Models;
using DEP.Service.Interfaces;
using DEP.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static DEP.Service.Services.AuthService;

namespace DEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IUserService userService;

        public AuthController(IAuthService service, IUserService userService)
        {
            this.authService = service;
            this.userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel request)
        {
            var auth = await authService.Login(request);

            if (auth is null)
            {
                return Unauthorized("Invalid login");
            }

            return Ok(auth);
        }

        [HttpPut("changepassword"), Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel viewModel)
        {
            var result = await authService.ChangePassword(viewModel);

            if (result == ChangePasswordResult.UserNotFound)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Bruger kunne ikke findes."
                });
            }

            if (result == ChangePasswordResult.WrongOldPassword)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Forkert gammel adgangskode."
                });
            }

            if (result == ChangePasswordResult.Failure)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Der er sket en uforventet fejl."
                });
            }

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Adgangskoden er blevet skiftet"
            });
        }


        [HttpPut("resetpassword"), Authorize]
        public async Task<IActionResult> ResetPassword(ChangePasswordViewModel viewModel)
        {
            var success = await authService.ResetPassword(viewModel.UserId);

            if (!success)
            {
                return BadRequest("Reset Password failed.");
            }

            return Ok(success);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken(AuthenticatedResponse authResponse)
        {
            if (authResponse is null)
            {
                return BadRequest("Der skete en uforventet fejl, log venligst ind igen.");
            }

            var user = await userService.GetUserById(authResponse.UserId);

            if (user.RefreshTokenExpiryDate <= DateTime.Now)
            {
                return Unauthorized("Din session er udløbet, log venligst ind igen.");
            }

            if (user is null)
            {
                return BadRequest("Kunne ikke loade bruger");
            }

            if (user.RefreshToken != authResponse.RefreshToken)
            {
                return Unauthorized("Brugeren er logget ind et andet sted, log venligst ind igen.");
            }

            var newAccessToken = authService.CreateJwtToken(user);

            var newRefreshToken = await authService.CreateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryDate = DateTime.Now.AddDays(1);
            await userService.UpdateUser(user);

            authResponse.AccessToken = newAccessToken;
            authResponse.RefreshToken = newRefreshToken;
            return Ok(authResponse);
        }
    }
}
