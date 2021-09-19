using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        
        public CourseController(SchoolDb _db)
        {
            db = _db;
            

        }

        
        

        // GET: CourseController
        public ActionResult Index()
        {
            var courses = db.Courses.ToList();
            return View(courses);

            //return View();

            //var courses = db.Courses.Include(t => t.Teachers).ToList();
            //return View(courses);
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
                db.Courses.Add(course);
                Commit();
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
                db.Courses.Update(newCourse);
                Commit();
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
        public ActionResult Delete(Course Obcourse)
        {
            try
            {
                db.Courses.Remove(Obcourse);
                Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public void Commit()
        {
            db.SaveChanges();
        }
    }
}
