using API.DTOs;

namespace API.Services.Interfaces
{
    public interface IAttendanceServices
    {
        Task DeleteAllAttendancesForStudentAsync(Guid studentId);
        Task AddAttendanceFromListAsync(List<AttendanceRequestDTO> attendanceDtoList);
        Task<IEnumerable<AttendanceDTO>> GetAttendancesForStudentAsync(Guid studentId);
    }
}
