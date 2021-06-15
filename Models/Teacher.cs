using SchoolApp.Data;
using System.Collections.Generic;

namespace SchoolApp.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }

        public int CourseId { get; set; }
        public List<Course> Courses { get; set; }


        //public List<Course> Courses { get; set; }


    }

    





}
