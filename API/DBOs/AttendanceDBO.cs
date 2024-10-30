namespace API.DBOs
{
    public class AttendanceDBO
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public int LessonNumber { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string Teacher { get; set; }
        public string AttendanceType { get; set; }
        public StudentDBO Student { get; set; }
    }
}
