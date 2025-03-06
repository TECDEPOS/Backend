    using DEP.Repository.Models;
using DEP.Repository.ViewModels;
using DEP.Service.Interfaces;
using DEP.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService service;

        public UsersController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetUsers()
        {
            var tt = await service.GetUsers();
            return Ok(tt);
            //return Ok(await service.GetUsers());
        }

        [HttpGet("educationBossesExcel")]
        public async Task<IActionResult> GetEducationBossesExcel()
        {
            return Ok(await service.GetEducationBossesExcel());
        }

        [HttpGet("educationBossExcel/{id:int}")]
        public async Task<IActionResult> GetEducationBossExcel(int id)
        {
            return Ok(await service.GetSelctedEducationBossExcel(id));
        }

        [HttpGet("educationLeaderExcel/{id:int}")]
        public async Task<IActionResult> GetEducationLeaderExcel(int id)
        {
            return Ok(await service.GetSelectedEducationLeaderExcel(id));
        }

        [HttpGet("educationleader/{id:int}"), Authorize]
        public async Task<IActionResult> GetUsersByEducationBossId(int id)
        {
            return Ok(await service.GetUsersByEducationBossId(id));
        }

        [HttpGet("userrole"), Authorize]
        public async Task<IActionResult> GetUsersByUserRole([FromQuery] UserRole userRole)
        {
            return Ok(await service.GetUsersByUserRole(userRole));
        }

        [HttpGet("{id:int}"), Authorize]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await service.GetUserById(id);

            if (user == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Bruger kunne ikke findes."
                });
            }

            return Ok(new ApiResponse<User>
            {
                Success = true,
                Message = "Bruger fundet",
                Data = user
            });
        }

        [HttpGet("dashboard/{id:int}"), Authorize]
        public async Task<IActionResult> GetUserDashboardById(int id)
        {
            var userDashboard = await service.GetUserDashboardById(id);

            if (userDashboard == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Bruger kunne ikke findes."
                });
            }

            return Ok(new ApiResponse<UserDashboardViewModel>
            {
                Success = true,
                Message = "Bruger fundet",
                Data = userDashboard
            });
        }

        [HttpGet("{name}"), Authorize]
        public async Task<IActionResult> GetUserByName(string name)
        {
            var user = await service.GetUserByName(name);

            if (user == null)
            {
                return NotFound($"Unable to find user with username: {name}");
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel viewModel)
        {
            var user = await service.GetUserByUsername(viewModel.Username);

            if (user is not null)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "En bruger med det brugernavn findes allerede."
                });
            }
            var newUser = await service.AddUser(viewModel);

            if (newUser is null)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Der opstod en fejl, brugeren blev ikke oprettet."
                });
            }

            return Ok(new ApiResponse<AddUserViewModel>
            {
                Success = true,
                Message = "Bruger oprettet.",
                Data = newUser
            });
        }

        [HttpPost("reassign-user")]
        public async Task<IActionResult> ReassignUser([FromBody] ReassignUserViewModel model)
        {
            return Ok(await service.ReassignUser(model));
        }

        [HttpDelete("{id:int}")/*, Authorize(Roles = "Administrator")*/]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userDeleted = await service.DeleteUser(id);

            if (userDeleted == false)
            {
                return BadRequest($"Something went wrong, user with ID={id} was not deleted.");
            }

            return Ok(userDeleted);
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> UpdateUser(User user)
        {
            return Ok(await service.UpdateUser(user));
        }
    }
}
