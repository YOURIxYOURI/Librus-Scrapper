namespace API.DTOs
{
    public class AttendanceDTO
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public int LessonNumber { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string Teacher { get; set; }
        public string AttendanceType { get; set; }
        public StudentDTO Student { get; set; }
    }

    public class AttendanceRequestDTO
    {
        public Guid? Id { get; set; }
        public int? LessonNumber { get; set; }
        public string? Subject { get; set; }
        public DateTime? Date { get; set; }
        public string? Teacher { get; set; }
        public string? AttendanceType { get; set; }
        public StudentDTO? Student { get; set; }
    }

    public class AttendanceResponseDTO
    {
        public Guid? Id { get; set; }
        public int? LessonNumber { get; set; }
        public string? Subject { get; set; }
        public DateTime? Date { get; set; }
        public string? Teacher { get; set; }
        public string? AttendanceType { get; set; }
    }
}
