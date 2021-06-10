using SchoolApp.Data;
using System.Collections.Generic;

namespace SchoolApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int TeacherId { get; set; }
        public Course Course { get; set; }


        SchoolDb db;
        public Teacher(SchoolDb _db)
        {
            db = _db;
        }



        public IList<Teacher> List()
        {
            return (IList<Teacher>)db.Teachers;
        }

        public Teacher Find(int id) 
        {
            var teacher = db.Teachers.Find(id);
            return teacher;
        }

        public void Add(Teacher teacher)
        {
            db.Teachers.Add(teacher);
            Commit();
        }

        public void Update(Teacher teacher) 
        {
            db.Update(teacher);
        }

        public void Delete(int id)
        {
            var teacher = Find(id);
            db.Teachers.Remove(teacher);
            Commit();
        }

        public void Commit()
        {
            db.SaveChanges();
        }






    }

    





}
