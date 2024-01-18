using DEP.Repository.Models;
using DEP.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonCoursesController : ControllerBase
    {
        private readonly IPersonCourseService service;

        public PersonCoursesController(IPersonCourseService service)
        {
            this.service = service;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetAllPersonCourses()
        {
            return Ok(await service.GetAllPersonCourses());
        }

        [HttpGet("person/{personId:int}"), Authorize]
        public async Task<IActionResult> GetPersonCoursesByPerson(int personId)
        {
            return Ok(await service.GetPersonCoursesByPerson(personId));
        }

        [HttpGet("course/{courseId:int}"), Authorize]
        public async Task<IActionResult> GetPersonCoursesByCourse(int courseId)
        {
            return Ok(await service.GetPersonCoursesByCourse(courseId));
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddPersonCourse(PersonCourse personCourse)
        {
            return Ok(await service.AddPersonCourse(personCourse));
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> UpdatePersonCourse(PersonCourse personCourse)
        {
            return Ok(await service.UpdatePersonCourse(personCourse));
        }

        [HttpDelete, Authorize]
        public async Task<IActionResult> DeletePersonCourse(int personId, int courseId)
        {
            var result = await service.DeletePersonCourse(personId, courseId);
            if (!result)
            {
                return BadRequest("Der opstod en fejl undervejs");
            }
            return Ok(result);
        }
    }
}
