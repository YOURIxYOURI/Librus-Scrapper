using API.DBOs;
using API.DTOs;
using API.Repositories.interfaces;
using API.Services.Interfaces;
using AutoMapper;

namespace API.Services
{
    public class StudentsService : IStudentsServices
    {
        private readonly IStudentsRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentsService(IStudentsRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
        {
            var studentDbos = await _studentRepository.GetAllStudentsAsync();
            return _mapper.Map<IEnumerable<StudentDTO>>(studentDbos);
        }

        public async Task<StudentDTO> GetStudentByIdAsync(Guid id)
        {
            var studentDbo = await _studentRepository.GetStudentByIdAsync(id);
            if (studentDbo == null) return null;

            return _mapper.Map<StudentDTO>(studentDbo);
        }

        public async Task AddStudentAsync(StudentDTO studentDto)
        {
            var studentDbo = _mapper.Map<StudentDBO>(studentDto);
            await _studentRepository.AddStudentAsync(studentDbo);
            await _studentRepository.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(StudentDTO studentDto)
        {
            var studentDbo = await _studentRepository.GetStudentByIdAsync(studentDto.Id);
            if (studentDbo == null) return;

            _mapper.Map(studentDto, studentDbo);
            await _studentRepository.UpdateStudentAsync(studentDbo);
            await _studentRepository.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            var studentDbo = await _studentRepository.GetStudentByIdAsync(id);
            if (studentDbo == null) return;

            await _studentRepository.DeleteStudentAsync(studentDbo);
            await _studentRepository.SaveChangesAsync();
        }
    }
}
