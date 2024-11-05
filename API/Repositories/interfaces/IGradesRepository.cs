using API.DBOs;

namespace API.Repositories.interfaces
{
    public interface IGradeRepository
    {
        Task<IEnumerable<GradesDBO>> GetAllGradesAsync();
        Task<GradesDBO> GetGradeByIdAsync(Guid? id);
        Task AddGradeAsync(GradesDBO gradeDbo);
        Task UpdateGradeAsync(GradesDBO gradeDbo);
        Task DeleteGradeAsync(GradesDBO gradeDbo);
        Task DeleteAllGradesByStudentIdAsync(Guid studentId);
        Task<bool> SaveChangesAsync();
    }
}
