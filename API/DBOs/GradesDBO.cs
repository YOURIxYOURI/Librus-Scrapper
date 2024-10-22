namespace API.DBOs
{
    public class GradesDBO
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Category { get; set; }
        public string Teacher { get; set; }
        public string GradeValue { get; set; }
        public string Weigth { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public bool CountToAvg { get; set; }
        public Guid StudentId { get; set; }
        public StudentDBO Student { get; set; }
    }
}
