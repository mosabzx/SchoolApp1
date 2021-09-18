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
    public class AssignmentController : Controller
    {

        SchoolDb db;
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
            return View();
        }

        // GET: AssignmentController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: AssignmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Assignment assignment)
        {
            try
            {
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
            return View();
        }

        // POST: AssignmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Assignment assignment)
        {
            try
            {
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
