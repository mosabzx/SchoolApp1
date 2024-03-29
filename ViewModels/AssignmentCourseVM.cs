﻿using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.ViewModels
{
    public class AssignmentCourseVM
    {
        public int AssignmentId { get; set; }
        [Required]
        public string Title { get; set; }

        public int CourseId { get; set; }
        public List<Course> Courses { get; set; }
    }
}
