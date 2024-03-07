using Check_Context_Diff_Proj.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Student
    {
    
        [Column("StudentId")]
        public Guid StudentId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Length must be less then 50 characters")]
        public string Name { get; set; }
        public int? Age { get; set; }
        //relationship between the Student and the StudentDetails
        public StudentDetails StudentDetails { get; set; }
        //one-2Many Relationship btw Student and Evaluation
        public ICollection<Evaluation> Evaluations { get; set; }
    }
}
