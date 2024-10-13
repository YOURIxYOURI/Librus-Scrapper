using API.DBOs;
using API.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly AppDbContext _context;

        public StudentsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentDBO>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<StudentDBO> GetStudentByIdAsync(Guid? id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task AddStudentAsync(StudentDBO student)
        {
            await _context.Students.AddAsync(student);
        }

        public async Task UpdateStudentAsync(StudentDBO student)
        {
            _context.Students.Update(student);
        }

        public async Task DeleteStudentAsync(StudentDBO student)
        {
            _context.Students.Remove(student);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
