using SchoolApp.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models
{
    public class Course
    {
        
        [Key]
        public int CId { get; set; }
        public string Material { get; set; }


        public Teacher Teacher { get; set; }
        
        public Assignment Assignment { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }

        
        


        

       

    }










}
