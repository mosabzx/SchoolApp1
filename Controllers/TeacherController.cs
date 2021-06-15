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
    public class TeacherController : Controller
    {
        SchoolDb db;
        Teacher teacher;
        
        public TeacherController(SchoolDb _db,Teacher _teacher)
        {
            db = _db;
            teacher = _teacher;
        }


        // GET: TeacherController
        public ActionResult Index()
        {
            var teacher = db.Teachers.ToList();
            return View(teacher);
        }

        // GET: TeacherController/Details/5
        public ActionResult Details(int id)

        {
            var teacher = db.Teachers.Find(id);
            return View(teacher);
        }

        // GET: TeacherController/Create
        public ActionResult Create()
        {

            var model = new Teacher
            {
                Courses = db.Courses.ToList()
            };

            return View(model);
            //return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher teacher)
        {
            try
            {
                 
                db.Teachers.Add(teacher);
                Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Teacher teacher)
        {
            try
            {
                db.Teachers.Update(teacher);
                Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TeacherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Teacher teacher)
        {
            try
            {
                db.Teachers.Remove(teacher);
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
