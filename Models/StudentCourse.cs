using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    public class StudentCourse
    {
        //Joining Entity for Student and Course.
        public int StudentId { get; set; } //ForeignKey
        public Student Student { get; set; }

        public int CourseId { get; set; } //ForeignKey
        public Course Course { get; set; }
        
    }
}
