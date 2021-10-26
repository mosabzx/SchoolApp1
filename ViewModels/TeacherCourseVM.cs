using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.ViewModels
{
    public class TeacherCourseVM 
    {
        public int TeacherId { get; set; }
        [Required]
        [DisplayName("Teacher Name")]
        public string TeacherName { get; set; }
        public int CourseId { get; set; }
        public List<Course> Courses { get; set; }
    }
}
