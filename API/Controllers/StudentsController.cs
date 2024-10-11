using API.DTOs;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsServices _studentService;

        public StudentsController(IStudentsServices studentService)
        {
            _studentService = studentService;
        }

        // GET: api/student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        // GET: api/student/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudentById(Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null) return NotFound();

            return Ok(student);
        }

        // POST: api/student
        [HttpPost]
        public async Task<ActionResult> AddStudent(StudentDTO studentDto)
        {
            await _studentService.AddStudentAsync(studentDto);
            return CreatedAtAction(nameof(GetStudentById), new { id = studentDto.Id }, studentDto);
        }

        // PUT: api/student/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent(Guid id, StudentDTO studentDto)
        {
            if (id != studentDto.Id) return BadRequest();

            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null) return NotFound();

            await _studentService.UpdateStudentAsync(studentDto);
            return NoContent();
        }

        // DELETE: api/student/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(Guid id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null) return NotFound();

            await _studentService.DeleteStudentAsync(id);
            return NoContent();
        }
    }
}
