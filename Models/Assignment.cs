using SchoolApp.Data;
using System.Collections.Generic;

namespace SchoolApp.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public string Title { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }




    }









}
