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
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;

        public StudentsService(IStudentsRepository studentRepository, IMapper mapper, IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentRequestDTO>> GetAllStudentsAsync()
        {
            var studentDbos = await _studentRepository.GetAllStudentsAsync();
            return _mapper.Map<IEnumerable<StudentRequestDTO>>(studentDbos);
        }

        public async Task<StudentRequestDTO> GetStudentByIdAsync(Guid? id)
        {
            var studentDbo = await _studentRepository.GetStudentByIdAsync(id);
            if (studentDbo == null) return null;

            return _mapper.Map<StudentRequestDTO>(studentDbo);
        }

        public async Task AddStudentAsync(StudentRequestDTO studentDto)
        {
            var studentDbo = _mapper.Map<StudentDBO>(studentDto);
            var controlVar = await _studentRepository.GetStudentByNameAndClassAsync(studentDbo.FirstName, studentDbo.LastName, studentDbo.Class);
            if (controlVar == null)
            {
                await _studentRepository.AddStudentAsync(studentDbo);
                await _studentRepository.SaveChangesAsync();
            }
        }

        public async Task UpdateStudentAsync(StudentRequestDTO studentDto)
        {
            var studentDbo = await _studentRepository.GetStudentByIdAsync(studentDto.Id);
            if (studentDbo == null) return;

            _mapper.Map(studentDto, studentDbo);
            await _studentRepository.UpdateStudentAsync(studentDbo);
            await _studentRepository.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(Guid? id)
        {
            var studentDbo = await _studentRepository.GetStudentByIdAsync(id);
            if (studentDbo == null) return;

            await _studentRepository.DeleteStudentAsync(studentDbo);
            await _studentRepository.SaveChangesAsync();
        }
        public async Task<bool> AddStudentWithGradesAsync(StudentRequestDTO studentDto)
        {
            var existingStudent = await _studentRepository.GetStudentByNameAndClassAsync(studentDto.FirstName, studentDto.LastName, studentDto.Class);

            if (existingStudent == null)
            {
                var newStudent = new StudentDBO
                {
                    FirstName = studentDto.FirstName,
                    LastName = studentDto.LastName,
                    Class = studentDto.Class
                };

                await _studentRepository.AddStudentAsync(newStudent);
                await _studentRepository.SaveChangesAsync();

                existingStudent = newStudent;
            }

            existingStudent.Grades.Clear();

            foreach (var gradeData in studentDto.Grades)
            {
                var newGrade = _mapper.Map<GradesDBO>(gradeData);
                newGrade.StudentId = existingStudent.Id;
                newGrade.Student = existingStudent;
                await _gradeRepository.AddGradeAsync(newGrade);
            }

            await _gradeRepository.SaveChangesAsync();

            return true;
        }
    }
}
