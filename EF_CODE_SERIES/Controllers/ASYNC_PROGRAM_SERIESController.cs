using EF_CODE_SERIES.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_CODE_SERIES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ASYNC_PROGRAM_SERIESController : ControllerBase
    {
        public readonly IStudent _student;
        public ASYNC_PROGRAM_SERIESController(IStudent student)
        {
            _student = student;
        }

        [HttpGet]
        [Route("GetStudentDetails")]
        public IActionResult GetStudentDetails()
        {
            var students = _student.GetAllStudents();

            return Ok(students);
        }
    }
}
