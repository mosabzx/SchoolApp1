using SchoolApp.Data;
using System.Collections.Generic;

namespace SchoolApp.Models
{
    public class Course
    {
        

        public int Id { get; set; }
        public string Material { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }

        public IList<Assignment> Assignments { get; set; }
        public Teacher Teacher { get; set; }


        

        SchoolDb db;
       
        public Course(SchoolDb _db)
        {
            db = _db;
            
        }




        public IList<Course> List()
        {

            return (IList<Course>)db.Courses;
        }

        public Course Find(int id)
        {
            var course = db.Courses.Find(id);
            return course;
        }

        public void Add(Course course)
        {
            db.Courses.Add(course);
            Commit();
        }

        public void Delete(int id)
        {
            var course = Find(id);
            db.Courses.Remove(course);
            Commit();
        }

        

        public void Update(Course newCourse) 
        {
            db.Update(newCourse);
            Commit();
        }



        public void Commit()
        {
            db.SaveChanges();
        }



    }










}
