using DEP.Repository.Models;
using DEP.Service.Interfaces;
using DEP.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService service;

        public PersonController(IPersonService service) { this.service = service; }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetPersons()
        {
            try
            {
                return Ok(await service.GetPersons());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("courseId/{courseId:int}"), Authorize]
        public async Task<IActionResult> GetPersonsByCourseId(int courseId)
        {
            return Ok(await service.GetPersonsByCourseId(courseId));
        }

        [HttpGet("notincourse/{courseId:int}"), Authorize]
        public async Task<IActionResult> GetPersonsNotInCourse(int courseId)
        {
            return Ok(await service.GetPersonsNotInCourse(courseId));
        }


        [HttpGet("{personId:int}"), Authorize]
        public async Task<IActionResult> GetPersonById(int personId)
        {
            var person = await service.GetPersonById(personId);
            if (person is null)
            {
                return NotFound($"Unable to find person with ID = {personId}");
            }
            return Ok(person);
        }
        //[HttpGet("{personId:int}/role/{roleId:int}"), Authorize]
        //public async Task<IActionResult> GetPersonById(int personId, int roleId)
        //{
        //    try
        //    {
        //        var person = await service.GetPersonById(personId, roleId);
        //        if (person is null)
        //        {
        //            return NotFound($"Unable to find person with ID = {personId}");
        //        }
        //        return Ok(person);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        [HttpGet("departmentId/{departmentId}/locationId{locationId}"), Authorize]
        public async Task<IActionResult> GetPersonsFromLocationAndDepartment(int departmentId, int locationId)
        {
            return Ok(await service.GetPersonsByDepartmentAndLocation(departmentId, locationId));
        }

        [HttpGet("{name}"), Authorize]
        public async Task<IActionResult> GetPersonByName(string name)
        {
            try
            {
                return Ok(await service.GetPersonsByName(name));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddPerson(Person person)
        {
            try
            {
                var result = await service.AddPerson(person);

                if (result is null)
                {
                    return BadRequest(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Der opstod en fejl, underviseren kunne ikke oprettes."
                    });
                }

                return Ok(new ApiResponse<Person>
                {
                    Success = true,
                    Message = "Bruger oprettet.",
                    Data = result
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> UpdatePerson(Person person)
        {
            try
            {
                return Ok(await service.UpdatePerson(person));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}"), Authorize]
        public async Task<IActionResult> DeletePerson(int id)
        {
            try
            {
                return Ok(await service.DeletePerson(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
