using AcademifyHub.Data;
using AcademifyHub.Entities;
using AcademifyHub.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;

namespace AcademifyHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {

        private readonly IWrittenExamsService _examsService;
        private readonly AppDbContext _appDbContext; 
        public ExamsController(IWrittenExamsService examsService  , AppDbContext appDbContext)
        {
            _examsService = examsService;
            _appDbContext = appDbContext;   
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var exam = await _examsService.GetById(id);

            if (exam == null)
                return NotFound();


            return Ok(exam);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] WrittenExam exam)
        {

            await _examsService.Add(exam);


            return Ok(exam);
        }
        [HttpGet]

        public async Task<IActionResult> GetAllExams()
        {
            var data = await _examsService.GetAll();
            return Ok(data);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] WrittenExam dto)
        {


    
        //public int CourseId { get; set; }
        var exam = await _examsService.GetById(id);

            if (exam == null)
                return NotFound($"No exam was found with ID {id}");

            var isValidGenre = await _examsService.IsvalidGenre(dto.Id);

            if (!isValidGenre)
                return BadRequest("Invalid exam ID!");



            exam.Title = dto.Title;
            exam.DurationInMinutes = dto.DurationInMinutes;
            exam.QuesionsNumber = dto.QuesionsNumber;
            exam.Instructions = dto.Instructions;
            exam.CourseId = dto.CourseId;
            


            var data = _examsService.Update(exam);
            return Ok(data);


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var exam = await _examsService.GetById(id);

            if (exam == null)
                return NotFound($"No examm was found with ID {id}");

            _examsService.Delete(exam);

            return Ok(exam);
        }

    }
}
