using DEP.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService service;

        public StatisticsController(IStatisticsService service)
        {
            this.service = service;
        }

        [HttpGet("personsperdepartment/module/{moduleId:int}")]
        public async Task<IActionResult> GetPersonPerDepartmentByModule(int moduleId)
        {
            return Ok(await service.GetPersonsPerDepartmentByModule(moduleId));
        }

        [HttpGet("personsperdepartment")]
        public async Task<IActionResult> GetPersonsPerDepartment()
        {
            return Ok(await service.GetPersonsPerDepartment());
        }

        [HttpGet("personsperlocation")]
        public async Task<IActionResult> GetPersonsPerLocation()
        {
            return Ok(await service.GetPersonsPerLocation());
        }

        [HttpGet("coursestatuscount/module/{moduleId:int}")]
        public async Task<IActionResult> GetCourseStatusCountByModule(int moduleId)
        {
            return Ok(await service.GetCourseStatusCountByModule(moduleId));
        }

        [HttpGet("personsperdepartmentandlocation")]
        public async Task<IActionResult> GetPersonsPerDepartmentAndLocation()
        {
            return Ok(await service.GetPersonsPerDepartmentAndLocation());
        }
    }
}
