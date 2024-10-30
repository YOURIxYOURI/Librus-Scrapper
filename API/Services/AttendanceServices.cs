using API.DBOs;
using API.DTOs;
using API.Repositories.interfaces;
using API.Services.Interfaces;
using AutoMapper;

namespace API.Services
{
    public class AttendanceServices : IAttendanceServices
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IMapper _mapper;

        public AttendanceServices(IAttendanceRepository attendanceRepository, IMapper mapper)
        {
            _attendanceRepository = attendanceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AttendanceDTO>> GetAttendancesForStudentAsync(Guid studentId)
        {
            var attendances = await _attendanceRepository.GetAttendancesByStudentIdAsync(studentId);
            return _mapper.Map<IEnumerable<AttendanceDTO>>(attendances);
        }

        public async Task AddAttendanceAsync(AttendanceRequestDTO attendanceDto)
        {
            var attendanceDTO = _mapper.Map<AttendanceDTO>(attendanceDto);
            var attendanceDBO = _mapper.Map<AttendanceDBO>(attendanceDTO);
            await _attendanceRepository.AddAttendanceAsync(attendanceDBO);
        }

        public async Task DeleteAllAttendancesForStudentAsync(Guid studentId)
        {
            await _attendanceRepository.DeleteAttendancesByStudentIdAsync(studentId);
        }

    }
}
