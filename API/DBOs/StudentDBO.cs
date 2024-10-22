namespace API.DBOs
{
    public class StudentDBO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        public IList<GradesDBO> Grades { get; set; } = new List<GradesDBO>();
    }
}
