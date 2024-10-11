using API.DTOs;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradesController : ControllerBase
    {
        private readonly IGradesServices _gradeService;

        public GradesController(IGradesServices gradeService)
        {
            _gradeService = gradeService;
        }

        // GET: api/grade
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradesDTO>>> GetAllGrades()
        {
            var grades = await _gradeService.GetAllGradesAsync();
            return Ok(grades);
        }

        // GET: api/grade/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GradesDTO>> GetGradeById(Guid id)
        {
            var grade = await _gradeService.GetGradeByIdAsync(id);
            if (grade == null) return NotFound();

            return Ok(grade);
        }

        // POST: api/grade
        [HttpPost]
        public async Task<ActionResult> AddGrade(GradesDTO gradeDto)
        {
            await _gradeService.AddGradeAsync(gradeDto);
            return CreatedAtAction(nameof(GetGradeById), new { id = gradeDto.Id }, gradeDto);
        }

        // PUT: api/grade/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGrade(Guid id, GradesDTO gradeDto)
        {
            if (id != gradeDto.Id) return BadRequest();

            var grade = await _gradeService.GetGradeByIdAsync(id);
            if (grade == null) return NotFound();

            await _gradeService.UpdateGradeAsync(gradeDto);
            return NoContent();
        }

        // DELETE: api/grade/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGrade(Guid id)
        {
            var grade = await _gradeService.GetGradeByIdAsync(id);
            if (grade == null) return NotFound();

            await _gradeService.DeleteGradeAsync(id);
            return NoContent();
        }
    }
}
