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

            modelBuilder.Entity<TeacherCourseVM>().HasNoKey();
            modelBuilder.Entity<AssignmentCourseVM>().HasNoKey();
            modelBuilder.Entity<StudentCourseVM>().HasNoKey();


        }
        

        public DbSet<SchoolApp.ViewModels.TeacherCourseVM> TeacherCourseVM { get; set; }
        

        public DbSet<SchoolApp.ViewModels.AssignmentCourseVM> AssignmentCourseVM { get; set; }
        

       



    }
}
