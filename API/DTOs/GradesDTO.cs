using API.DBOs;

namespace API.DTOs
{
    public class GradesDTO
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Category { get; set; }
        public string Teacher { get; set; }
        public string GradeValue { get; set; }
        public string Weigth { get; set; }
        public string Comment { get; set; }
        public bool CountToAvg { get; set; }
        public DateTime Date { get; set; }
        public Guid StudentID { get; set; }
        public StudentDBO Student { get; set; }
    }
    public class GradesRequestDTO
    {
        public Guid? Id { get; set; }
        public string? Subject { get; set; }
        public string? Category { get; set; }
        public string? Teacher { get; set; }
        public string? GradeValue { get; set; }
        public string? Weigth { get; set; }
        public string? Comment { get; set; }
        public bool? CountToAvg { get; set; }
        public DateTime? Date { get; set; }
        public Guid? StudentID { get; set; }
        public StudentDBO? Student { get; set; }
    }
    public class GradesResponseDTO
    {
        public Guid? Id { get; set; }
        public string? Subject { get; set; }
        public string? Category { get; set; }
        public string? Teacher { get; set; }
        public string? GradeValue { get; set; }
        public string? Weigth { get; set; }
        public string? Comment { get; set; }
        public bool? CountToAvg { get; set; }
        public DateTime? Date { get; set; }
    }
}
