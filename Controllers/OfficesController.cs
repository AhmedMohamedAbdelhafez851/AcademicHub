using AcademifyHub.Entities;
using AcademifyHub.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademifyHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OfficesController : ControllerBase
    {
        private readonly IOfficesService _officeService;
        public OfficesController(IOfficesService officeService)
        {
            _officeService = officeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var office = await _officeService.GetById(id);

            if (office == null)
                return NotFound();


            return Ok(office);
        }

        [HttpPost]
       // [AllowAnonymous]
        public async Task<IActionResult> Create([FromForm] Office office)
        {

            await _officeService.Add(office);

            return Ok(office);
        }
        [HttpGet]

        public async Task<IActionResult> GetAllOffices()
        {
            var data = await _officeService.GetAll();
            return Ok(data);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] Office dto)
        {
            var office = await _officeService.GetById(id);

            if (office == null)
                return NotFound($"No office was found with ID {id}");

            var isValidGenre = await _officeService.IsvalidGenre(dto.Id);

            if (!isValidGenre)
                return BadRequest("Invalid office ID!");


            office.OfficeName = dto.OfficeName;
            office.OfficeLocation = dto.OfficeLocation;

            var data = _officeService.Update(office);
            return Ok(data);


        }
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var office = await _officeService.GetById(id);

            if (office == null)
                return NotFound($"No office was found with ID {id}");

            _officeService.Delete(office);

            return Ok(office);
        }
    }
}
