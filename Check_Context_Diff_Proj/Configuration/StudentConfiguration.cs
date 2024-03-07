using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_Context_Diff_Proj.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
          builder.ToTable(nameof(Student));
        //    builder.Property(s => s.Age)
        //.IsRequired(false);
        //    builder.Property(s => s.IsRegularStudent)
        //        .HasDefaultValue(true);
        builder.HasData(new Student
        {
           StudentId = Guid.NewGuid(),
            Name = "Adrian",
            Age = 1
        },new Student
        {
            StudentId = Guid.NewGuid(),
            Name = "Anish",
            Age = 40
        },new Student
        {
            StudentId = Guid.NewGuid(),
            Name = "Anu",
            Age = 34
        });

        }
    }
}
