using DEP.Repository.Models;
using DEP.Service.Interfaces;
using DEP.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(await service.GetUsers());
        }

        [HttpGet("educationleader/{id:int}"), Authorize]
        public async Task<IActionResult> GetUsersByEducationBossId(int id)
        {
            return Ok(await service.GetUsersByEducationBossId(id));
        }

        [HttpGet("userrole"), Authorize]
        public async Task<IActionResult> GetUsersByUserRole(UserRole userRole)
        {
            return Ok(await service.GetUsersByUserRole(userRole));
        }

        [HttpGet("{id:int}"), Authorize]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await service.GetUserById(id);

            if (user == null)
            {
                return NotFound($"Unable to find user with ID: {id}");
            }

            return Ok(user);
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
                return BadRequest("An account with that username already exists.");
            }
            var newUser = await service.AddUser(viewModel);

            if (newUser is null)
            {
                return BadRequest("An error has occurred, user could not be created");
            }

            return Ok(newUser);
        }

        [HttpDelete("{id:int}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userDeleted = await service.DeleteUser(id);

            if (userDeleted == false)
            {
                return BadRequest($"Something went wrong, user with ID={id} was not deleted.");
            }

            return NoContent();
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> EditUser(User user)
        {
            return Ok(await service.UpdateUser(user));
        }
    }
}
