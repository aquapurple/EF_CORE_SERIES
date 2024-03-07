using Check_Context_Diff_Proj.Configuration;
using Entities;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Identity.Client;

namespace Entities
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions options):base(options)
        {
           
    }
        //EF Core looks for all the public DbSet properties, inside the application’s context class,
        /// <summary>
        /// and then maps their names to the names of the tables in the database.
        /// </summary>
        public DbSet<Student> student { get; set; }

        //this method can be used if we dont have separate configFile for each DataTable
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Student>()
        //        .ToTable("Student");
        //    modelBuilder.Entity<Student>()
        //        .Property(s => s.Age);
        //        //.IsRequired(false);
        //    //modelBuilder.Entity<Student>()
        //    //    .Property(s => s.IsRegularStudent)
        //    //    .HasDefaultValue(true);
        //    modelBuilder.Entity<Student>()
        //        .HasData(
        //            new Student
        //            {
        //                StudentId = Guid.NewGuid(),
        //                Name = "John Doe",
        //                Age = 30
        //            },
        //            new Student
        //            {
        //                StudentId = Guid.NewGuid(),
        //                Name = "Jane Doe",
        //                Age = 25
        //            }
        //        );
        //}


        //this method can be used if we  have separate configFile for each DataTable
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration( new StudentConfiguration() );
            modelBuilder.ApplyConfiguration(new StudentSubjectConfiguration());
        }


    }
}
