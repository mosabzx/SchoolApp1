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
    public class TeacherController : Controller
    {
       private readonly SchoolDb db;
        

        public TeacherController(SchoolDb _db)
        {
            db = _db;
            
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

            var model = new TeacherCourseVM
            {
                
                Courses = db.Courses.ToList(),
            };

            


            return View(model);


        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult  Create(TeacherCourseVM model)
        {
            try
            {


                var course = db.Courses.Find(model.CourseId);
                Teacher teacher = new Teacher
                {
                    TeacherId = model.TeacherId,
                    TeacherName = model.TeacherName,
                    Course = course
                };

                db.Teachers.Add(teacher);
                Commit();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                //throw new Exception(ex.InnerException.Message);
                return View();
            }
        }

        // GET: TeacherController/Edit/5
        public ActionResult Edit(int id)
        {
            var teacher = db.Teachers.Find(id);
            var ViewModel = new TeacherCourseVM
            {
                TeacherId = teacher.TeacherId,
                TeacherName = teacher.TeacherName,
                CourseId = teacher.CourseId,
                Courses = db.Courses.ToList()
            };
            return View(ViewModel);
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeacherCourseVM model)
        {
            try
            {
                var course = db.Courses.Find(model.CourseId);
                Teacher teacher = new Teacher
                {
                    TeacherId = model.TeacherId,
                    TeacherName = model.TeacherName,
                    Course = course
                };
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
            var teacher = db.Teachers.Find(id);
            return View(teacher);
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
