using AcademifyHub.Entities;
using AcademifyHub.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace AcademifyHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SectionsController : ControllerBase
    {
        private readonly ISectionsService _SectionService;
        public SectionsController(ISectionsService SectionService)
        {
            _SectionService = SectionService;
        }

        [HttpGet("{id}")]
         
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var Section = await _SectionService.GetById(id);

            if (Section == null)
                return NotFound();


            return Ok(Section);
        }

        [HttpPost]
       

        public async Task<IActionResult> Create([FromForm]Section section)
        {

            await _SectionService.Add(section);

            return Ok(section);
        }
        [HttpGet]

        public async Task<IActionResult> GetAllSections()
        { 
            var data = await _SectionService.GetAll();
            return Ok(data);
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateAsync(int id, [FromForm] Section dto)
        {
            var section = await _SectionService.GetById(id);

            if (section == null)
                return NotFound($"No section was found with ID {id}");

            var isValidGenre = await _SectionService.IsvalidGenre(dto.Id);

            if (!isValidGenre)
                return BadRequest("Invalid section ID!");


            section.SectionName = dto.SectionName;
            section.TimeSlot.StartTime = dto.TimeSlot.StartTime;    
            section.TimeSlot.EndTime = dto.TimeSlot.EndTime;
            section.DateRange.StartDate = dto.DateRange.StartDate; 
            section.DateRange.EndDate = dto.DateRange.EndDate;
            section.CourseId = dto.CourseId;
            section.InstructorId = dto.InstructorId;    
            section.ScheduleId = dto.ScheduleId;    
            
             

            var data = _SectionService.Update(section);
            return Ok(data);


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var section = await _SectionService.GetById(id);

            if (section == null)
                return NotFound($"No section was found with ID {id}");

            _SectionService.Delete(section);

            return Ok(section);
        }


    }
}
