using DEP.Service.Interfaces;
using DEP.Service.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using File = DEP.Repository.Models.File;

namespace DEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService service;

        public FileController(IFileService service) { this.service = service; }

        [HttpGet]
        public async Task<IActionResult> GetFile()
        {
            try
            {
                return Ok(await service.GetFile());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetFileById(int id)
        {
            try
            {
                var file = await service.GetFileById(id);
                if (file == null)
                {
                    return NotFound("Awww Dang it!");
                }
                return Ok(file);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetFileByName(string name)
        {
            try
            {
                var file = await service.GetFileByName(name);
                if (file == null)
                {
                    return NotFound("Better luck next time!");
                }
                return Ok(file);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(File file)
        {
            try
            {
                if(file == null)
                {
                    return NotFound("File not Given? Be better than that!");
                }
                return Created("File", await service.AddFile(file));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /*[HttpPut]
        public async Task<IActionResult> UpdateFile(File file)
        {
            try
            {
                if(file is null)
                {
                    return NotFound("What piece of sheeeit is this!?");
                }
                return Ok(await service.UpdateFile(file));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        } */

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Deletefile(int id)
        {
            try
            {
                return Ok(await service.DeleteFile(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
