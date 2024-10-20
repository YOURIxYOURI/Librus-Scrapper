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
        public async Task<ActionResult<StudentDTO>> GetStudentById(Guid? id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null) return NotFound();

            return Ok(student);
        }

        // POST: api/student
        [HttpPost]
        public async Task<ActionResult> AddStudent([FromBody] StudentRequestDTO studentDto)
        {
        {
            await _studentService.AddStudentAsync(studentDto);
            return Ok();
        }

        // PUT: api/student/{id}
        [HttpPut]
        public async Task<ActionResult> UpdateStudent([FromBody] StudentRequestDTO studentDto)
        {
            var student = await _studentService.GetStudentByIdAsync(studentDto.Id);
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
