using DEP.Repository.Models;
using DEP.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonModuleController : ControllerBase
    {
        private readonly IPersonModuleService service;
        public PersonModuleController(IPersonModuleService service) { this.service = service; }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetAllPersonModules()
        {
            return Ok(await service.GetAllPersonModules());
        }

        [HttpGet("{id:int}"), Authorize]
        public async Task<IActionResult> GetPersonModule(int id)
        {
            return Ok(await service.GetPersonModule(id));
        }

        [HttpGet("{personId:int}/{moduleId:int}"), Authorize]
        public async Task<IActionResult> GetPersonModules(int personId, int moduleId)
        {
            return Ok(await service.GetPersonModules(personId, moduleId));
        }

        [HttpGet("person/{personId:int}"), Authorize]
        public async Task<IActionResult> GetPersonModulesByPerson(int personId)
        {
            return Ok(await service.GetPersonModulesByPerson(personId));
        }

        [HttpDelete("{id:int}"), Authorize]
        public async Task<IActionResult> DeletePersonModule(int id)
        {
            return Ok(await service.DeletePersonModule(id));
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddPersonModule(PersonModule personModule)
        {
            return Ok(await service.AddPersonModule(personModule));
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> UpdatePersonModule(PersonModule personModule)
        {
            return Ok(await service.UpdatePersonModule(personModule));
        }
    }
}
