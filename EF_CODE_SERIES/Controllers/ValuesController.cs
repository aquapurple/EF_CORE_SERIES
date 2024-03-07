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
    //    [HttpGet]
    //    public IActionResult Get()
    //    {
    //        var entity = _context.Model
    //.FindEntityType(typeof(Student).FullName);
    //        var tableName = entity.GetTableName();
    //        var schemaName = entity.GetSchema();
    //        var key = entity.FindPrimaryKey();
    //        var properties = entity.GetProperties();
            
    //    }
    }
}
