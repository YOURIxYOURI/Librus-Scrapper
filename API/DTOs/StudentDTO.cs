using API.DBOs;

namespace API.DTOs
{
    public class StudentDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        public IList<GradesDTO> Grades { get; set; } = new List<GradesDTO>();
        public IList<AttendanceDBO> Attendances { get; set; } = new List<AttendanceDBO>();
    }
    public class StudentRequestDTO
    {
        public Guid? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Class { get; set; }
        public IList<GradesRequestDTO>? Grades { get; set; } = new List<GradesRequestDTO>();
        public IList<AttendanceRequestDTO>? Attendances { get; set; } = new List<AttendanceRequestDTO>();
    }

    public class StudentResponseDTO
    {
        public Guid? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Class { get; set; }
        public IList<GradesResponseDTO>? Grades { get; set; } = new List<GradesResponseDTO>();
        public IList<AttendanceResponseDTO>? Attendances { get; set; } = new List<AttendanceResponseDTO>();
    }

}
