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

        public ActionResult StudentCourseIndex()
        {
            var studentCourse = db.StudentCourses.ToList();
            return View(studentCourse);
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


            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {



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

        [HttpGet]
        public ActionResult AssignToCourses(int id)
        {
            ViewBag.Conflict = TempData["Conflict"];

            var courses = new StudentCourseVM
            {
                StudentId = id,
                StudentName = db.Students.Where(s => s.StudentId == id).SingleOrDefault().StudentName,


                Students = db.Students.ToList(),
                Courses = db.Courses.ToList(),


            };

            return View(courses);
        }
        [HttpPost]
        public ActionResult AssignToCourses(StudentCourseVM model, List<int> CourseIds)
        {
            var studentCourseIDs = new StudentCourse();
            var ConflictList = new List<int>();
            


            var check = db.StudentCourses.Where(sc => sc.StudentId == model.StudentId).Select(sc => new { existId = sc.CourseId });



            foreach (var courseId in CourseIds)
            {
                foreach (var id in check)
                    if (id.existId == courseId)
                    {
                        ConflictList.Add(courseId);

                    }

            }

            foreach (var courseId in CourseIds)
            {
                foreach (var id in ConflictList)
                {
                    if (id == courseId)
                    {
                        TempData["Conflict"] = $"The Course Id's {String.Join(" ,", ConflictList)} Is already assigned for this student Id {model.StudentId}, please check the index's pages and reassigned again";

                        return RedirectToAction("AssignToCourses");
                    }

              
                }

                studentCourseIDs.StudentId = model.StudentId;
                studentCourseIDs.CourseId = courseId;
                db.StudentCourses.Add(studentCourseIDs);
                Commit();


            }




            return RedirectToAction(nameof(StudentCourseIndex));

            //return View();



        }


        public void Commit()
        {
            db.SaveChanges();
        }




    }
}
