namespace API.DTOs
{
    public class StudentDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        public IList<GradesDTO> Grades { get; set; } = new List<GradesDTO>();
    }
    public class StudentRequestDTO
    {
        public Guid? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Class { get; set; }

        public IList<GradesRequestDTO>? Grades { get; set; } = new List<GradesRequestDTO>();
    }
}
