using AcademifyHub.Entities;
using AcademifyHub.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademifyHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorsService _instructorService;
        public InstructorsController(IInstructorsService courseService)
        {
            _instructorService = courseService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var instructor = await _instructorService.GetById(id);

            if (instructor == null)
                return NotFound();


            return Ok(instructor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Instructor instructor)
        {

            await _instructorService.Add(instructor);

            return Ok(instructor);
        }
        [HttpGet]

        public async Task<IActionResult> GetAllInstructors()
        {
            var data = await _instructorService.GetAll();
            return Ok(data);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] Instructor dto)
        {
            var instructor = await _instructorService.GetById(id);

            if (instructor == null)
                return NotFound($"No instructor was found with ID {id}");

            var isValidGenre = await _instructorService.IsvalidGenre(dto.Id);

            if (!isValidGenre)
                return BadRequest("Invalid instructor ID!");


            instructor.FName = dto.FName;
            instructor.LName = dto.LName; 
            instructor.OfficeId = dto.OfficeId;
 
            var data = _instructorService.Update(instructor);
            return Ok(data);


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var instructor = await _instructorService.GetById(id);

            if (instructor == null)
                return NotFound($"No instructor was found with ID {id}");

            _instructorService.Delete(instructor);

            return Ok(instructor);
        }
    }
}
