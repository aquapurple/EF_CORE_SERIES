using Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EF_CODE_SERIES.Interfaces
{
    public interface IStudent
    {
        IEnumerable<Student> GetAllStudents();
    }
}
