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

        public async Task AddAttendanceFromListAsync(StudentRequestDTO requestDTO)
        {
            var existingStudent = await _studentsRepository.GetStudentByNameAndClassAsync(requestDTO.FirstName, requestDTO.LastName, requestDTO.Class);

            if (existingStudent == null)
            {
                var newStudent = new StudentDBO
                {
                    FirstName = requestDTO.FirstName,
                    LastName = requestDTO.LastName,
                    Class = requestDTO.Class
                };

                await _studentsRepository.AddStudentAsync(newStudent);
                await _studentsRepository.SaveChangesAsync();

                existingStudent = newStudent;
            }

            await _attendanceRepository.DeleteAttendancesByStudentIdAsync(existingStudent.Id);

            foreach (var data in requestDTO.Attendances)
            {
                var newData = _mapper.Map<AttendanceDBO>(data);
                newData.StudentId = existingStudent.Id;
                newData.Student = existingStudent;
                await _attendanceRepository.AddAttendanceAsync(newData);
            }

            await _attendanceRepository.SaveChangesAsync();
        }

        public async Task DeleteAllAttendancesForStudentAsync(Guid studentId)
        {
            await _attendanceRepository.DeleteAttendancesByStudentIdAsync(studentId);
        }

    }
}
