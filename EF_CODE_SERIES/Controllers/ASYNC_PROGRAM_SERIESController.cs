using EF_CODE_SERIES.Interfaces;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_CODE_SERIES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ASYNC_PROGRAM_SERIESController : ControllerBase
    {
        public readonly IStudent _student;
        public readonly IStudentAsync _studentAsync;
        public ASYNC_PROGRAM_SERIESController(IStudent student, IStudentAsync studentAsync)
        {
            _student = student;
            _studentAsync = studentAsync;

        }

        [HttpGet]
        [Route("GetStudentDetails")]
        public IActionResult GetStudentDetails()
        {
            var students = _student.GetAllStudents();

            return Ok(students);
        }


        [HttpGet]
        [Route("GetStudentDetailsAsync")]
        public async Task<IActionResult> GetStudentDetailsAsync()
        {
            var students = await _studentAsync.GetAllStudents();

            return Ok(students);
        }

        [HttpGet]
        [Route("{Ids}", Name ="GetStudentDetailsAsyncID")]
        public async Task<IActionResult> GetStudentDetailsAsyncID(Guid Ids)
        {
            var students = await _studentAsync.GetStudent(Ids);

            return Ok(students);
        }

        [HttpPost(Name ="CreateStudent")]
     //   [Route("GetStudentDetailsAsyncID")]
        public async Task<IActionResult> CreateStudent([FromBody]Student student )
        {
          await _studentAsync.CreateStudent(student);
            return CreatedAtRoute("GetStudentDetailsAsyncID", new { Ids = student.StudentId }, student);

           // return Ok(students);
        }

    }
}

