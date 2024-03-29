﻿using Microsoft.AspNetCore.Http;
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

            
        }




        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {

            //var courseId = db.Courses.Where(c => c.CourseId == id).FirstOrDefault().CourseId;
            var TiedTeachers = (from t in db.Teachers
                               join c in db.Courses
                               on t.CourseId equals c.CourseId
                               where c.CourseId == id
                               select t);
            var TiedAssignments = (from a in db.Assignments
                                  join c in db.Courses
                                  on a.CourseId equals c.CourseId
                                  where c.CourseId == id
                                  select a);
            var TiedStudents = (from s in db.Students
                                join sc in db.StudentCourses
                                on s.StudentId equals sc.StudentId
                                where sc.CourseId == id
                                select s);


            var courseDetails = new CourseDetailsVM
            {
                CourseId = id,
                Course = db.Courses.Find(id),
                CList = db.Courses.ToList(),
                TList = TiedTeachers.ToList(),
                Alist = TiedAssignments.ToList(),
                SList = TiedStudents.ToList(),
            };


            return View(courseDetails);


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
            var course = db.Courses.Find(id);
            return View(course);
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
            var course = db.Courses.Find(id);
            return View(course);
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
