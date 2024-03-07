using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EF_CODE_SERIES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ADD_UPD_DBController : ControllerBase
    {
        public readonly ApplicationContext _context;
        public ADD_UPD_DBController(ApplicationContext context)

        {
            _context = context;

        }
        [HttpPost]
        [Route("api/Add_Record_ADDMethod")]
        public IActionResult Add_Record_ADDMethod([FromBody] Student student)
        {
            if (student == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();
            _context.Add(student);
            _context.SaveChanges();
            return Created("URI of the created entity", student);
        }


        [HttpPost("api/Add_Record_ADDRANGEMethod")]
        public IActionResult PostRange([FromBody] IEnumerable<Student> students)
        {
            //additional checks
            _context.AddRange(students);
            _context.SaveChanges();
            return Created("URI is going here", students);
        }
    }
}
