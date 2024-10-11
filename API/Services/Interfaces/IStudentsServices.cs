using API.DTOs;

namespace API.Services.Interfaces
{
    public interface IStudentsServices
    {
        Task<IEnumerable<StudentDTO>> GetAllStudentsAsync();
        Task<StudentDTO> GetStudentByIdAsync(Guid id);
        Task AddStudentAsync(StudentDTO studentDto);
        Task UpdateStudentAsync(StudentDTO studentDto);
        Task DeleteStudentAsync(Guid id);
    }
}
