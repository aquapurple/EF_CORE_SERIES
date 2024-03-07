using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_Context_Diff_Proj.Entities
{
    public class StudentDetails
    {
        [Column("StudentDetailsId")]
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string AdditionalInformation { get; set; }


        //a foreign key and the navigation property Student
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
