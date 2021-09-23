using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Models;
using SchoolApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Controllers
{
    public class StudentController : Controller
    {

       private readonly SchoolDb db;

        public StudentController(SchoolDb _db)
        {
            db = _db;
        }


        // GET: StudentController
        public ActionResult Index()
        {
            var students = db.Students.ToList();
            return View(students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var student = db.Students.Find(id);
            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            //var model = new StudentCourseVM
            //{
            //    Courses = db.Courses.ToList()
            //};
            
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                //var course = db.Courses.Find(model.CourseId);
                //var student = new Student
                //{
                //    StudentId = model.StudentId,
                //    StudentName = model.StudenName,
                //    StudentCourses = 
                //};


                db.Students.Add(student);
                Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var student = db.Students.Find(id);
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                db.Students.Update(student);
                Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var studen = db.Students.Find(id);
            return View(studen);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Student student)
        {
            try
            {
               
                db.Students.Remove(student);
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
