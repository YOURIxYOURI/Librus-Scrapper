using API.DBOs;
using API.DTOs;
using API.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class GradesRepository : IGradeRepository
    {
        private readonly AppDbContext _context;

        public GradesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GradesDBO>> GetAllGradesAsync()
        {
            return await _context.Grades.ToListAsync();
        }

        public async Task<GradesDBO> GetGradeByIdAsync(Guid id)
        {
            return await _context.Grades.FindAsync(id);
        }

        public async Task AddGradeAsync(GradesDBO grade)
        {
            await _context.Grades.AddAsync(grade);
        }

        public async Task UpdateGradeAsync(GradesDBO gradeDbo)
        {
            _context.Grades.Update(gradeDbo);
        }

        public async Task DeleteGradeAsync(GradesDBO gradeDbo)
        {
            _context.Grades.Remove(gradeDbo);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
