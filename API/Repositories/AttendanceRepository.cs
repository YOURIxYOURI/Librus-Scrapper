using API.DBOs;
using API.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AppDbContext _context;

        public AttendanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AttendanceDBO>> GetAttendancesByStudentIdAsync(Guid studentId)
        {
            return await _context.Attendances
                .Where(attendance => attendance.StudentId == studentId).ToListAsync();
        }

        public async Task AddAttendanceAsync(AttendanceDBO attendance)
        {
            await _context.Attendances.AddAsync(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAttendancesByStudentIdAsync(Guid studentId)
        {
            var attendances = _context.Attendances
                .Where(attendance => attendance.StudentId == studentId);

            _context.Attendances.RemoveRange(attendances);
            await _context.SaveChangesAsync();
        }
    }
}
