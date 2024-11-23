using API.DTOs;

namespace API.Services.Interfaces
{
    public interface IStudentsServices
    {
        Task<IEnumerable<StudentRequestDTO>> GetAllStudentsAsync();
        Task<StudentRequestDTO> GetStudentByIdAsync(Guid? id);
        Task AddStudentAsync(StudentRequestDTO studentDto);
        Task UpdateStudentAsync(StudentRequestDTO studentDto);
        Task DeleteStudentAsync(Guid? id);
        Task<bool> AddStudentWithGradesAsync(StudentRequestDTO studentDto);
        Task<StudentResponseDTO> GetStudentWithDetailsAsync(StudentRequestDTO request);
    }
}
