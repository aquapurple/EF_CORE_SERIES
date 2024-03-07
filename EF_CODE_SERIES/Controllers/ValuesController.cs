using Check_Context_Diff_Proj;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Entities;

namespace EF_CODE_SERIES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly  ApplicationContext _context;
        public ValuesController(ApplicationContext context)

        {
            _context = context;
            
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
              .Where(s => s.Age > 25)
              .ToList();

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
    }
}
