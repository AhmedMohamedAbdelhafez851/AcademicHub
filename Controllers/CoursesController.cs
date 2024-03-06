using AcademifyHub.Data;
using AcademifyHub.Entities;
using AcademifyHub.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Diagnostics.Contracts;

namespace AcademifyHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [AllowAnonymous]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesService _courseService;
        public CoursesController(ICoursesService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var course = await _courseService.GetById(id);

            if (course == null)
                return NotFound();

 
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]Course course)
        {

           await _courseService.Add(course);

            return Ok(course);
        }
        [HttpGet]
       
        public async Task<IActionResult> GetAllCourses()
        {
             var data =await _courseService.GetAll(); 
            return Ok(data);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] Course dto)
        { 
            var course = await _courseService.GetById(id);

            if (course == null)
                return NotFound($"No course was found with ID {id}");

            var isValidGenre = await _courseService.IsvalidGenre(dto.Id);

            if (!isValidGenre)
                return BadRequest("Invalid course ID!");


            course.CourseName = dto.CourseName;
            course.HoursToComplete = dto.HoursToComplete;   
            course.Price = dto.Price;   

            var data = _courseService.Update(course);
            return Ok(data);


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var course = await _courseService.GetById(id);

            if (course == null)
                return NotFound($"No course was found with ID {id}");

            _courseService.Delete(course);

            return Ok(course);
        }


    }
}
