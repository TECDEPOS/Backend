using DEP.Service.Interfaces;
using DEP.Service.ViewModels;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await service.GetUsers());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await service.GetUserById(id);

            if (user == null)
            {
                return NotFound($"Unable to find user with ID: {id}");
            }

            return Ok(user);
        }

        [HttpGet("{name}")]
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

            var newUser = await service.AddUser(viewModel);

            if (newUser == null)
            {
                return BadRequest("An error has occurred.");
            }

            return Ok(newUser);
        }
    }
}
