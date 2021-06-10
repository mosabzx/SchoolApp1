using SchoolApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }

        SchoolDb db;
        public Student(SchoolDb _db)
        {
            db = _db;
        }



        IList<Student> List()
        {
            return (IList<Student>)db.Students;
        }

        public Student Find(int id)
        {
            var student = db.Students.Find(id);
            return student;
        }

        public void Add(Student student)
        {
            db.Students.Add(student);
            Commit();
        }

        public void Delete(int id)
        {
            var student = Find(id);
            db.Students.Remove(student);
            Commit();
        }



        public void Update(Student newStudent)
        {
            db.Update(newStudent);
            Commit();
        }



        public void Commit()
        {
            db.SaveChanges();
        }




    }









}
