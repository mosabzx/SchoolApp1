using SchoolApp.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models
{
    public class Course
    {
        

        public int Id { get; set; }
        
        public string Material { get; set; }
        public Teacher Teacher { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }

        public IList<Assignment> Assignments { get; set; }
        


        

       

    }










}
