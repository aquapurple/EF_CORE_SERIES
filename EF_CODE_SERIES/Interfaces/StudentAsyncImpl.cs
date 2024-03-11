using Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_CODE_SERIES.Interfaces
{
    public class StudentAsyncImpl:IStudentAsync
    {
        public readonly ApplicationContext _context;

        public StudentAsyncImpl(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _context.student.Include(x => x.StudentDetails).
                OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Student> GetStudent(Guid StuId)
        {
            return await _context.student.Include(y=>y.StudentDetails).SingleOrDefaultAsync(s => s.StudentId.Equals(StuId));
        }

        public async Task CreateStudent(Student student)
        {
            _context.AddRange(student);
             await _context.SaveChangesAsync();
        }
    }
}
