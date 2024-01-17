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
        private readonly ICourseService service;
        public PersonModuleController(ICourseService service) { this.service = service; }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetAllPersonModules()
        {
            return Ok(await service.GetAllCourses());
        }

        [HttpGet("{id:int}"), Authorize]
        public async Task<IActionResult> GetPersonModule(int id)
        {
            return Ok(await service.GetCourseById(id));
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
            return Ok(await service.DeleteCourse(id));
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddPersonModule(Course personModule)
        {
            return Ok(await service.AddCourse(personModule));
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> UpdatePersonModule(Course personModule)
        {
            return Ok(await service.UpdateCourse(personModule));
        }
    }
}
