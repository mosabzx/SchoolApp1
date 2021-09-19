using SchoolApp.Data;
using System.Collections.Generic;

namespace SchoolApp.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public string Title { get; set; }

        public int CId { get; set; }
        public Course Course { get; set; }







        //SchoolDb db;
        //public Assignment(SchoolDb _db)
        //{
        //    db = _db;
        //}


        //IList <Assignment> List()
        //{
        //    return (IList<Assignment>)db.Assignments;
        //}

        //public Assignment Find(int id)
        //{
        //    var assignment = db.Assignments.Find(id);
        //    return assignment;
        //}

        //public void Add(Assignment assignment)
        //{
        //    db.Assignments.Add(assignment);
        //    Commit();
        //}

        //public void Delete(int id)
        //{
        //    var assignment = Find(id);
        //    db.Assignments.Remove(assignment);
        //    Commit();
        //}



        //public void Update(Assignment newAssignment)
        //{
        //    db.Update(newAssignment);
        //    Commit();
        //}


        //public void Commit()
        //{
        //    db.SaveChanges();
        //}


    }









}
