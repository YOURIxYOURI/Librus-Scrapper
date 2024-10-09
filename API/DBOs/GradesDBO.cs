namespace API.DBOs
{
    public class GradesDBO
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string GradeValue { get; set; }
        public DateTime Date { get; set; }
        public StudentDBO Student { get; set; }
    }
}
