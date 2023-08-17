using DEP.Repository.Models;
using DEP.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonModuleController : ControllerBase
    {
        private readonly IPersonModuleService service;
        public PersonModuleController(IPersonModuleService service) { this.service = service; }

        [HttpGet("{personId:int}/{moduleId:int}/{date:DateTime}")]
        public async Task<IActionResult> GetPersonModule(int personId, int moduleId, DateTime date)
        {
            return Ok(await service.GetPersonModule(personId, moduleId, date));
        }

        [HttpGet("personmodules/{personId:int}/{moduleId:int}")]
        public async Task<IActionResult> GetPersonModules(int personId, int moduleId)
        {
            return Ok(await service.GetPersonModules(personId, moduleId));
        }

        [HttpDelete("{personId:int}/{moduleId:int}/{date:DateTime}")]
        public async Task<IActionResult> DeletePersonModule(int personId, int moduleId, DateTime date)
        {
            return Ok(await service.DeletePersonModule(personId, moduleId, date));
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonModule(PersonModule personModule)
        {
            return Ok(await service.AddPersonModule(personModule));
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePersonModule(PersonModule personModule)
        {
            return Ok(await service.UpdatePersonModule(personModule));
        }
    }
}
