﻿using DEP.Repository.Models;
using DEP.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService service;
        public CoursesController(ICourseService service) { this.service = service; }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetAllCourses()
        {
            return Ok(await service.GetAllCourses());
        }

        [HttpGet("module/{id:int}"), Authorize]
        public async Task<IActionResult> GetCoursesByModuleId(int id)
        {
            return Ok(await service.GetCoursesByModuleId(id));
        }

        [HttpGet("{id:int}"), Authorize]
        public async Task<IActionResult> GetCourseById(int id)
        {
            return Ok(await service.GetCourseById(id));
        }

        [HttpDelete("{id:int}"), Authorize]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            return Ok(await service.DeleteCourse(id));
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddCourse(Course course)
        {
            return Ok(await service.AddCourse(course));
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> UpdateCourse(Course course)
        {
            return Ok(await service.UpdateCourse(course));
        }
    }
}