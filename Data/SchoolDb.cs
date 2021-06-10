using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            //One to One.
            modelBuilder.Entity<Course>()
                .HasOne<Teacher>(t => t.Teacher)
                .WithOne(c => c.Course)
                .HasForeignKey<Teacher>(t => t.TeacherId);

            //One to Many.
            modelBuilder.Entity<Course>()
                .HasMany<Assignment>(a => a.Assignments)
                .WithOne(c => c.Course)
                .HasForeignKey(ca => ca.AssignemtId);

            //Many To Many.
            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.SId, sc.CId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne<Student>(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.SId);
            modelBuilder.Entity<StudentCourse>()
                .HasOne<Course>(sc => sc.Course)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.CId);




        }



    }
}
