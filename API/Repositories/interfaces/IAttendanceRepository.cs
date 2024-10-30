using API.DBOs;

namespace API.Repositories.interfaces
{
    public interface IAttendanceRepository
    {
        Task DeleteAttendancesByStudentIdAsync(Guid studentId);
        Task AddAttendanceAsync(AttendanceDBO attendance);
        Task<IEnumerable<AttendanceDBO>> GetAttendancesByStudentIdAsync(Guid studentId);
    }
}
