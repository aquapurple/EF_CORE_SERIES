﻿using Check_Context_Diff_Proj.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_CODE_SERIES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadValuesConfigController : ControllerBase
    {
private readonly IConfiguration _configuration;
        public ReadValuesConfigController(IConfiguration configuration)
        {
            _configuration= configuration;
          }



        [HttpGet]
        [Route("api/ReadValuesFromAppSett")]
        public string ReadValuesFromAppSett()
        {
            var students = _configuration.GetValue<string>("ConnectionStrings:sqlConnection1");
            var names = _configuration.GetValue<string>("Myvalues:Name");

            return students.ToString() + names.ToString();
        }

        [HttpGet]
        [Route("api/ReadValuesGroupAppSett")]
        public string ReadValuesGroupAppSett()
        {
            var vals = _configuration.GetSection("Myvalues").Get<Myvalues>();
            var mob = vals.mobile;


            return mob.Number1;
        }
    }
}
