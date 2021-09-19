using SchoolApp.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }

        public int CId { get; set; }
        public Course Course { get; set; }


        


    }

    





}
