namespace API.DBOs
{
    public class StudentDBO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class {  get; set; }
        public IList<StudentDBO> Grades { get; set; }
    }
}
