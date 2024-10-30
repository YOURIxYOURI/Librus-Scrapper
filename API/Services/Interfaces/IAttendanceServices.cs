using API.DTOs;

namespace API.Services.Interfaces
{
    public interface IAttendanceServices
    {
        Task DeleteAllAttendancesForStudentAsync(Guid studentId);
        Task AddAttendanceAsync(AttendanceRequestDTO attendanceDto);
        Task<IEnumerable<AttendanceDTO>> GetAttendancesForStudentAsync(Guid studentId);
    }
}
