using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.ViewModels
{
    public class CourseDetailsVM
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public IList<Course> CList { get; set; }
        public IList<Student> SList { get; set; }
        public IList<Assignment> Alist { get; set; }
        public IList<Teacher> TList { get; set; }


    }
}
