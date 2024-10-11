using API.DBOs;

namespace API.Repositories.interfaces
{
    public interface IStudentsRepository
    {
        Task<IEnumerable<StudentDBO>> GetAllStudentsAsync();
        Task<StudentDBO> GetStudentByIdAsync(Guid id);
        Task AddStudentAsync(StudentDBO student);
        Task UpdateStudentAsync(StudentDBO student);
        Task DeleteStudentAsync(StudentDBO student);
        Task<bool> SaveChangesAsync();
    }
}
