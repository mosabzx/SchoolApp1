using SchoolApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }

       




    }









}
