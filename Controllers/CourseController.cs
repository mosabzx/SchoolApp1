using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Data;
using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Controllers
{
    public class CourseController : Controller
    {
       private readonly SchoolDb db;
        public Course Obcourse;
        public CourseController(SchoolDb _db,Course Obcourse)
        {
            db = _db;
            this.Obcourse = Obcourse;

        }

        
        //public CourseController(Course course )
        //{
        //    this.course = course;
        //}


        // GET: CourseController
        public ActionResult Index()
        {

            var courses = db.Courses;
            return View(courses);
        }


        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            var course = db.Courses.Find(id);
            return View(course);
        }


        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            try
            {
                Obcourse.Add(course);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Course newCourse)
        {
            try
            {
                Obcourse.Update(newCourse);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Course Obcourse)
        {
            try
            {
                Obcourse.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
