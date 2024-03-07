using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Check_Context_Diff_Proj.Entities
{
    public class Evaluation
    {
        [Column("EvaluationId")]
        public Guid Id { get; set; }
        [Required]
        public int Grade { get; set; }
        public string AdditionalExplanation { get; set; }

        ////one-2Many Relationship btw Student and Evaluation
        //Data Annotations Approach
        [ForeignKey(nameof(Student))]
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
