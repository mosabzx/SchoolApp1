using SchoolApp.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models
{
    public class Course
    {

        
        public int CourseId { get; set; }
        [Required]
        public string Material { get; set; }

       
        public IList<Teacher> Teachers { get; set; }

       
        public IList<Assignment> Assignments { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }

        
        


        

       

    }










}
