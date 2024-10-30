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

        [HttpPost("{studentId}")]
        public async Task<IActionResult> AddAttendance(Guid studentId, [FromBody] AttendanceDTO attendanceDto)
        {
            await _service.AddAttendanceAsync(attendanceDto, studentId);
            return Ok();
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteAttendances(Guid studentId)
        {
            await _service.DeleteAllAttendancesForStudentAsync(studentId);
            return NoContent();
        }
    }
}
