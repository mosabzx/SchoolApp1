using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.ViewModels
{
    public class StudentCourseVM
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public List<Student> Students { get; set; }
        public int CourseId { get; set; }
        public List<Course> Courses  { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
