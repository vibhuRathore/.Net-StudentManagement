using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManagement.Database;
using StudentManagement.Models;

namespace StudentManagement.Repository
{
    public class StudentRepository : IStudent
    {

        private readonly StudentManagementEntities3 _DB;
        
        public StudentRepository()
        {
            _DB = new StudentManagementEntities3();
        }

        public List<SelectListItem> Subjectlist()
        {
            List<SelectListItem> StudentSubject = new List<SelectListItem>();
            StudentSubject.Add(new SelectListItem { Text = "--Select Subject-- ", Value = "0", Selected = true });
            StudentSubject.Add(new SelectListItem { Text = "Maths", Value = "1" });
            StudentSubject.Add(new SelectListItem { Text = "Bio", Value = "2" });
            StudentSubject.Add(new SelectListItem { Text = "Chemistry", Value = "3" });
            return (StudentSubject);
        }
        public void Delete(int? Id)
        {
            var dataToBeDeleted = _DB.DataStudents.FirstOrDefault(x => x.StudentId == Id);
            _DB.DataStudents.Remove(dataToBeDeleted);
        }

        public DataStudent findStudent(int? Id)
        {
            return _DB.DataStudents.Find(Id);
        }

        public IEnumerable<StudentDataModel> GetStudents()
        {
            //var students1 = _DB.DataStudents.AsEnumerable();
            //var students2 = _DB.DataStudents.AsQueryable();
            var students = _DB.DataStudents.ToList();
            var data = new List<StudentDataModel>();

            foreach (var student in students)
            {
                var model = new StudentDataModel
                {
                    StudentId = student.StudentId,
                    StudentName = student.StudentName,
                    StudentSubject = student.StudentSubject,
                    StudentAge = (int)student.StudentAge,
                    SubjectList = Subjectlist()
                };
                data.Add(model);
            }
            return data;
        }

        public void Insert(DataStudent recievedstudentData)
        {
            _DB.DataStudents.Add(recievedstudentData);
        }

        public void Save()
        {
            _DB.SaveChanges();
        }

        public void Update(StudentDataModel recievedstudentData)
        {
            throw new NotImplementedException();
        }
    }
}