using DEP.Repository.Models;
using DEP.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileTagController : ControllerBase
    {
        private readonly IFileTagService service;

        public FileTagController(IFileTagService service) { this.service = service; }

        [HttpGet]
        public async Task<IActionResult> GetFileTag()
        {
            return Ok(await service.GetFileTags());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFileTagById(int id)
        {
            try
            {
                var file = await service.GetFileTagById(id);
                if (file == null)
                {
                    return NotFound();
                }
                return Ok(file);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetFileTagByName(string name)
        {
            try
            {
                var file = await service.GetFileTagByName(name);
                if (file == null)
                {
                    return NotFound();
                }
                return Ok(file);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddFileTag(FileTag fileTag)
        {
            try
            {
                if (fileTag == null)
                {
                    return NotFound("FileTag not Given? Be better than that!");
                }
                
                return Created("file", await service.AddFileTag(fileTag));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFileTag(FileTag fileTag)
        {
            try
            {
                if (fileTag == null)
                {
                    return NotFound("FileTag not given? Dont be a goat!");
                }
                return Ok(await service.UpdateFileTag(fileTag));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteFileTag(int id)
        {
            try
            {
                return Ok(await service.DeleteFileTag(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
