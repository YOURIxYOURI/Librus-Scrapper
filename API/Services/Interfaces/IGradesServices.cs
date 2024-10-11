using API.DTOs;

namespace API.Services.Interfaces
{
    public interface IGradesServices
    {
        Task<IEnumerable<GradesDTO>> GetAllGradesAsync();
        Task<GradesDTO> GetGradeByIdAsync(Guid id);
        Task AddGradeAsync(GradesDTO gradeDto);
        Task UpdateGradeAsync(GradesDTO gradeDto);
        Task DeleteGradeAsync(Guid id);
    }
}
