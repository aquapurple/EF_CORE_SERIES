using Check_Context_Diff_Proj;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Entities;
using System.Diagnostics;
using System;
using EF_CODE_SERIES.Interfaces;

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
              .Include(x => x.StudentDetails)
              .Where(s => s.Age > 10)
            .ToList();

            //var students = _context.student
            //    .Include(a => a.StudentDetails)
            //    .AsSplitQuery()
            //    .ToList();

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


        [HttpGet]
        [Route("api/GroupBy")]
        public IActionResult GroupBy()
        {
            var grouped_teachers = _context.student
                  .GroupBy(t => new { t.Age })
                  .Select(g => new
                  {
                      Age = g.Key.Age,
                      count = g.Count(), //number of students in the group
                      names = string.Join(", ", g.Select(t => t.Name)) // students names
                  });
            return Ok(grouped_teachers);

            //foreach (var group in grouped_teachers)
            //{
            //    Console.WriteLine($"Subject: {group.subject}, Age: {group.age}, Count: {group.count}, Names: {group.names}");
            //}
        }


        [HttpGet]
        [Route("api/GroupByMatch")]
        public IActionResult GroupByMatch()
        {
            var grouped_Students = _context.student
                  .GroupBy(t => new { V = t.Name.StartsWith("A") })
                  .Select(g => new
                  {
                      Name = g.Key.V,
                      count = g.Count(), //number of students in the group
                      names = string.Join(", ", g.Select(t => t.Name)) // students names
                  });
            return Ok(grouped_Students);
        }
    }
}
