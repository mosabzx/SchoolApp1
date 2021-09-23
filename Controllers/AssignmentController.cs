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
    public class AssignmentController : Controller
    {

        private readonly SchoolDb db;
        public AssignmentController(SchoolDb _db)
        {
            db = _db;
        }


        // GET: AssignmentController
        public ActionResult Index()
        {
            var assignment = db.Assignments.ToList();
            return View(assignment);
        }

        // GET: AssignmentController/Details/5
        public ActionResult Details(int id)
        {
            var assignment = db.Assignments.Find(id);
            return View(assignment);
        }

        // GET: AssignmentController/Create
        public ActionResult Create()
        {
            var model = new AssignmentCourseVM
            {
                Courses = db.Courses.ToList()
            };
            return View(model);
        }

        // POST: AssignmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssignmentCourseVM model)
        {
            try
            {
                var course = db.Courses.Find(model.CourseId);
                var assignment = new Assignment
                {
                    AssignmentId = model.AssignmentId,
                    Title = model.Title,
                    Course =course

                };

                db.Assignments.Add(assignment);
                Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssignmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var assignment = db.Assignments.Find(id);
            var ViewModel = new AssignmentCourseVM
            {
                AssignmentId = assignment.AssignmentId,
                Title = assignment.Title,
                CourseId = assignment.CourseId,
                Courses = db.Courses.ToList()
                
            };
            return View(ViewModel);
        }

        // POST: AssignmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AssignmentCourseVM model)
        {
            try
            {
                var course = db.Courses.Find(model.CourseId);
                var assignment = new Assignment
                {
                    AssignmentId = model.AssignmentId,
                    Title = model.Title,
                    Course = course

                };

                db.Assignments.Update(assignment);
                Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssignmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var assignment = db.Assignments.Find(id);
            return View(assignment);
        }

        // POST: AssignmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Assignment assignment)
        {
            try
            {
                db.Assignments.Remove(assignment);
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
