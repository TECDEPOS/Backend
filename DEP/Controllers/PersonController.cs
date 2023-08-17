using DEP.Repository.Models;
using DEP.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService service;

        public PersonController(IPersonService service) { this.service = service; }

        [HttpGet]
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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPersonById(int id)
        {
            try
            {
                return Ok(await service.GetPersonById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("name")]
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

        [HttpPost]
        public async Task<IActionResult> AddPerson(Person person)
        {
            try
            {
                if(person is null)
                {
                    return BadRequest("You have given me SHEIIIT!");
                }
                return Created("Person", await service.AddPerson(person));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerson(Person person)
        {
            try
            {
                if(person is null)
                {
                    return BadRequest("What kind of dog piss are this?!");
                }
                return Ok(await service.UpdatePerson(person));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("id")]
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
