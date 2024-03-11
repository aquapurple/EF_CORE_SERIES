using Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_CODE_SERIES.Interfaces
{
    public class StudentIMPL : IStudent
    {
        public readonly ApplicationContext _context;

        public StudentIMPL(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            return _context.student.Include(x=>x.StudentDetails).
                
                OrderBy(x=>x.Name).ToList();
        }
    }
}
