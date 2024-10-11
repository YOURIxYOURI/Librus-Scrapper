using API.DBOs;
using API.DTOs;

namespace API.Repositories.interfaces
{
    public interface IGradeRepository
    {
        Task<IEnumerable<GradesDBO>> GetAllGradesAsync();
        Task<GradesDBO> GetGradeByIdAsync(Guid id);
        Task AddGradeAsync(GradesDBO gradeDbo);
        Task UpdateGradeAsync(GradesDBO gradeDbo);
        Task DeleteGradeAsync(GradesDBO gradeDbo);
        Task<bool> SaveChangesAsync();
    }
}
