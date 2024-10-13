using API.DTOs;

namespace API.Services.Interfaces
{
    public interface IGradesServices
    {
        Task<IEnumerable<GradesRequestDTO>> GetAllGradesAsync();
        Task<GradesRequestDTO> GetGradeByIdAsync(Guid? id);
        Task AddGradeAsync(GradesRequestDTO gradeDto);
        Task UpdateGradeAsync(GradesRequestDTO gradeDto);
        Task DeleteGradeAsync(Guid? id);
    }
}
