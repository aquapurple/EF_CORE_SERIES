using Check_Context_Diff_Proj;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Entities;
using System.Diagnostics;

namespace EF_CODE_SERIES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly  ApplicationContext _context;
        private readonly ILogger _logger;
        public ValuesController(ApplicationContext context, ILogger<ValuesController> logger)

        {
            _context = context;
            _logger = logger;


        }
     //      [HttpGet]
     //   public IActionResult Get()
     //   {
     //       var students = _context.student
     //         .Where(s => s.Age > 25)
     //         .ToList();
            
     //return Ok(students);

     //      }


        [HttpGet]
        [Route("api/Retrieve")]
        public IActionResult Retrive()
        {
            var students = _context.student
              .AsNoTracking()
              .Include(x=>x.StudentDetails)
              .Where(s => s.Age > 10)
              .ToList();

            return Ok(students);
        }


        [HttpGet]
        [Route("api/RetrieveSelectedField")]
        public IActionResult RetrieveSelectedField()
        {

            var stopwath=Stopwatch.StartNew();
            stopwath.Start();
            Stopwatch stp = new Stopwatch();

            var students = (_context.student
              .AsNoTracking()
              .Include(x => x.StudentDetails)
              .Where(s => s.Age > 10)
              .ToList()).Select(c => new { c.Name,c.Age });
            stopwath.Stop();

            var message = $"Processesd in: {stopwath.Elapsed}";
            _logger.LogInformation(message);


            return Ok(students);
        }




        [HttpGet]
        [Route("api/Stud_WithEvaluation")]
        public IActionResult Stud_WithEvaluation()
        {
            var students = _context.student
             .Include(e => e.Evaluations)
             .FirstOrDefault();

            return Ok(students);
        }


        [HttpGet]
        [Route("api/Stud_WithEvaluationThenInclude")]
        public IActionResult Stud_WithEvaluationThenInclude()
        {
            var students = _context.student
             .Include(e => e.Evaluations)
             .Include(e=>e.StudentDetails)
             .Include(f=>f.StudentSubjects)
             .FirstOrDefault();

            return Ok(students);
        }


        [HttpGet]
        [Route("api/Retrieve_SELECT_option")]
        public IActionResult Retrieve_SELECT_option()
        {
            var students = _context.student
    .Select(s => new
    {
        s.Name,
        s.Age,
        NumberOfEvaluations = s.Evaluations.Count
    })
    .ToList();

            return Ok(students);
        }


        [HttpGet]
        [Route("api/FROMSQLRAW_Method")]
        public IActionResult FROMSQLRAW_Method()
        {
            var students = _context.student
     .FromSqlRaw(@"SELECT * FROM Student WHERE Name = {0}", "Adrian")
     .FirstOrDefault();

            return Ok(students);
        }

        [HttpGet]
        [Route("api/FROMSQLRAW_Method_StorPROC")]
        public IActionResult FROMSQLRAW_Method_StorPROC()
        {
            var students = _context.student
       .FromSqlRaw("EXECUTE dbo.sp_johnzFirst")
    .ToList();

            return Ok(students);
        }


        [HttpGet]
        [Route("api/FROMSQLRAW_Method_SINCLUDE")]
        public IActionResult FROMSQLRAW_Method_SINCLUDE()
        {
            var students = _context.student
     .FromSqlRaw("SELECT * FROM Student WHERE Name = {0}", "Adrian")
     .Include(e => e.Evaluations)
     .FirstOrDefault();

            return Ok(students);
        }

        [HttpGet]
        [Route("api/FROMSQLRAW_Method_UPDATE")]
        public IActionResult FROMSQLRAW_Method_UPDATE()
        {
            var rowsAffected = _context.Database
      .ExecuteSqlRaw(
          @"UPDATE Student
          SET Age = {0} 
          WHERE Name = {1}", 29, "Anu");
            return Ok(new { RowsAffected = rowsAffected });
        }
    }
}
