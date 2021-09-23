using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.ViewModels
{
    public class TeacherCourseVM 
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public int CourseId { get; set; }
        public List<Course> Courses { get; set; }
    }
}
