using DEP.Service.Interfaces;
using DEP.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                return Unauthorized("Bad login");
            }

            return Ok(auth);
        }

        [HttpPut("changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel viewModel)
        {
            var success = await authService.ChangePassword(viewModel);

            if (!success)
            {
                return BadRequest("Change Password failed.");
            }

            return Ok(success);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken(AuthenticatedResponse authResponse)
        {
            if (authResponse is null)
            {
                return BadRequest("Invalid client Request");
            }

            string refreshToken = authResponse.RefreshToken;

            var user = await userService.GetUserById(authResponse.UserId);

            if (user.RefreshTokenExpiryDate <= DateTime.Now)
            {
                return BadRequest("Your session has expired, please log in again.");
            }

            if (user is null || user.RefreshToken != refreshToken)
            {
                return BadRequest("Invalid Request");
            }

            var newAccessToken = authService.CreateJwtToken(user);
            var newRefreshToken = await authService.CreateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await userService.UpdateUser(user);

            authResponse.AccessToken = newAccessToken;
            authResponse.RefreshToken = newRefreshToken;
            return Ok(authResponse);
        }
    }
}
