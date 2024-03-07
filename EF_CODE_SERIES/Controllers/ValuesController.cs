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
        public IActionResult Get()
        {
            var students = _context.student
              .AsNoTracking()
              .Where(s => s.Age > 25)
              .ToList();

            return Ok(students);
        }
    }
}
