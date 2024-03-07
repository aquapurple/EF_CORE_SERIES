using Check_Context_Diff_Proj.Entities;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


        [HttpPost("api/Add_AdditionalDetails")]
        public IActionResult Post([FromBody] Student student)
        {
            //validation code goes here
            student.StudentDetails = new StudentDetails
            {
                Address = "Added Address john",
                AdditionalInformation = "Additional information added"
            };
            _context.Add(student);
            _context.SaveChanges();
            return Created("URI of the created entity", student);
        }


        [HttpPut("{id}")]
        public IActionResult Update_rec(Guid id, [FromBody] Student student)
        {
            var dbStudent = _context.student
                .FirstOrDefault(s => s.StudentId.Equals(id));
            dbStudent.Age = student.Age;
            dbStudent.Name = student.Name;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}/Relationship")]
        public IActionResult Update_rec_Relational(Guid id, [FromBody] Student student)
        {
            var dbStudent = _context.student
       .Include(s => s.StudentDetails)
       .FirstOrDefault(s => s.StudentId.Equals(id));
            dbStudent.Age = student.Age;
            dbStudent.Name = student.Name;
            dbStudent.StudentDetails.AdditionalInformation = "Additional information updated";
            dbStudent.StudentDetails.Address = "CoffeeBoard Layout";
            _context.SaveChanges();
            return NoContent();
        }


        [HttpPut("{id}/UpdateRelationhip")]
        public IActionResult UpdateRelationhip(Guid id, [FromBody] Student student)
        {
            var dbStudent = _context.student
                .FirstOrDefault(s => s.StudentId.Equals(id));
            dbStudent.StudentDetails = new StudentDetails
            {
                Id = new Guid("e2a3c45d-d19a-4603-b983-7f63e2b86f14"),
                Address = "added address",
                AdditionalInformation = "Additional information for student 2",
                StudentId=id
            };
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}/relationshipDElete")]
        public IActionResult relationshipDElete(Guid id)
        {
            var student = _context.student
                .Include(s => s.StudentDetails)
                .FirstOrDefault(s => s.StudentId.Equals(id));
            if (student == null)
                return BadRequest();
            _context.Remove(student);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
