using Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EF_CODE_SERIES.Interfaces
{
    public interface IStudentAsync
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudent(Guid StuId);
        Task CreateStudent(Student student);
    }
}
