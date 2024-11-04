using API.DBOs;
using API.DTOs;
using API.Repositories.interfaces;
using API.Services.Interfaces;
using AutoMapper;

namespace API.Services
{
    public class AttendanceServices : IAttendanceServices
    {
        private readonly IStudentsRepository _studentsRepository;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IMapper _mapper;

        public AttendanceServices(IAttendanceRepository attendanceRepository, IMapper mapper, IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
            _attendanceRepository = attendanceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAttendancesForStudentAsync(Guid studentId)
        {
            var attendances = await _attendanceRepository.GetAttendancesByStudentIdAsync(studentId);
            return _mapper.Map<IEnumerable<AttendanceDTO>>(attendances);
        }

        public async Task AddAttendanceFromListAsync(List<AttendanceRequestDTO> attendanceDtoList)
        {
            foreach (var attendanceDto in attendanceDtoList)
            {
                var student = await _studentsRepository.GetStudentByNameAndClassAsync(attendanceDto.Student.FirstName, attendanceDto.Student.LastName, attendanceDto.Student.Class);

                if (student == null)
                {
                    throw new ArgumentException("Student not found.");
                }

                var attendanceEntry = _mapper.Map<AttendanceDBO>(attendanceDto);
                attendanceEntry.StudentId = student.Id;
                await _attendanceRepository.AddAttendanceAsync(attendanceEntry);
            }
        }

        public async Task DeleteAllAttendancesForStudentAsync(Guid studentId)
        {
            await _attendanceRepository.DeleteAttendancesByStudentIdAsync(studentId);
        }

    }
}
