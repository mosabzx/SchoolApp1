using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.ViewModels
{
    public class StudentCourseViewModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }


    }
}
