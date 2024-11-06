using API.DTOs;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly IAttendanceServices _service;

        public AttendancesController(IAttendanceServices service)
        {
            _service = service;
        }

        [HttpGet("{studentId}")]
        public async Task<ActionResult<IEnumerable<AttendanceDTO>>> GetAttendances(Guid studentId)
        {
            var attendances = await _service.GetAttendancesForStudentAsync(studentId);
            return Ok(attendances);
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteAttendances(Guid studentId)
        {
            await _service.DeleteAllAttendancesForStudentAsync(studentId);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> PostAttendance([FromBody] StudentRequestDTO attendanceList)
        {
            if (attendanceList == null || !attendanceList.Attendances.Any())
            {
                return BadRequest("Brak danych obecności do zapisania.");
            }

            try
            {
                await _service.AddAttendanceFromListAsync(attendanceList);

                return Ok("Dane obecności zapisane pomyślnie.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Błąd podczas zapisu danych obecności: {ex.Message}");
            }
        }
    }
}
