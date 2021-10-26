using SchoolApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    public class Student 
    {
        
        [Key]
        public int StudentId { get; set; }
        [Required]
        [DisplayName("Student name")]
        public string StudentName { get; set; }
       

        public IList<StudentCourse> StudentCourses { get; set; }

       




    }









}
