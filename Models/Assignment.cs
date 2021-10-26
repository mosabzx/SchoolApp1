using SchoolApp.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        [Required]
        public string Title { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }




    }









}
