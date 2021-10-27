using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApp.ViewModels;

namespace SchoolApp.Data
{
    public class SchoolDb : DbContext

    {
        public SchoolDb(DbContextOptions<SchoolDb> options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to Many.
            modelBuilder.Entity<Course>()
                .HasMany<Teacher>(t => t.Teachers)
                .WithOne(c => c.Course)
                .HasForeignKey(fk => fk.CourseId);

            //One to Many.
            modelBuilder.Entity<Course>()
                .HasMany<Assignment>(a => a.Assignments)
                .WithOne(c => c.Course)
            .HasForeignKey(fk => fk.CourseId);

            //Many To Many.
            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne<Student>(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);
            modelBuilder.Entity<StudentCourse>()
                .HasOne<Course>(sc => sc.Course)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

          
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = -1, Material = "----Select Course----" },
                new Course { CourseId = 1, Material = "Programming" },
                new Course { CourseId = 2, Material = "English" },
                new Course { CourseId = 3, Material = "Math" });

            modelBuilder.Entity<Student>().HasData(
               new Student { StudentId = 1, StudentName = "Mario" },
               new Student { StudentId = 2, StudentName = "Bismark" },
               new Student { StudentId = 3, StudentName = "Michael" });

            modelBuilder.Entity<Assignment>().HasData(
               new Assignment { AssignmentId = 1, Title = "C#", CourseId = 1 },
               new Assignment { AssignmentId = 2, Title = "JavaScript", CourseId = 1 },
               new Assignment { AssignmentId = 3, Title = "Story", CourseId = 2 },
               new Assignment { AssignmentId = 4, Title = "Cover Letter", CourseId = 2 },
               new Assignment { AssignmentId = 5, Title = "Addition", CourseId = 3 },
               new Assignment { AssignmentId = 6, Title = "multiplication", CourseId = 3 });

            modelBuilder.Entity<Teacher>().HasData(
               new Teacher { TeacherId = 1, TeacherName = "Alfred", CourseId = 1 },
               new Teacher { TeacherId = 2, TeacherName = "Eva", CourseId = 2 },
               new Teacher { TeacherId = 3, TeacherName = "Johan", CourseId = 3 });

            modelBuilder.Entity<StudentCourse>().HasData(
                new StudentCourse { CourseId = 3, StudentId = 2 },
                new StudentCourse { CourseId = 3, StudentId = 1 },
                new StudentCourse { CourseId = 1, StudentId = 1 },
                new StudentCourse { CourseId = 3, StudentId = 3 },
                new StudentCourse { CourseId = 2, StudentId = 1 });


        }


        //public DbSet<SchoolApp.ViewModels.TeacherCourseVM> TeacherCourseVM { get; set; }


        //public DbSet<SchoolApp.ViewModels.AssignmentCourseVM> AssignmentCourseVM { get; set; }


        //public DbSet<SchoolApp.ViewModels.StudentCourseVM> StudentCourseVM { get; set; }






    }
}
