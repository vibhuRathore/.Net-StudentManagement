
using StudentManagement.Models;
using StudentManagement.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Core.Metadata.Edm;
using Newtonsoft.Json.Linq;
using System.Web.Helpers;
using StudentManagement.Repository;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private IStudent _studentRepository;

         public StudentController()
        {
            _studentRepository = new StudentRepository();
        }
 
        public ActionResult Index()
        {
            var model = _studentRepository.GetStudents();
            ViewBag.list = _studentRepository.Subjectlist();
            return View(model);
        }
        [HttpGet]
        public ActionResult ListOfStudents()
        {
            var data = _studentRepository.GetStudents();
            return Json(data , JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddStudent(int? Id) {
            StudentDataModel model = new StudentDataModel
            {
                SubjectList = _studentRepository.Subjectlist()
            };
            if (Id != null)
            {

                var DataToBeUpdated = _studentRepository.findStudent(Id);
                model.StudentId = DataToBeUpdated.StudentId;
                model.StudentName = DataToBeUpdated.StudentName;
                model.StudentAge = DataToBeUpdated.StudentAge;
                model.StudentSubject = DataToBeUpdated.StudentSubject;
                model.SubjectList = _studentRepository.Subjectlist();
                return PartialView("_listOfStudents", model);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AddStudent(StudentDataModel recievedstudentData)
        {

                if (recievedstudentData.StudentId == null)
            {
                var student = new DataStudent();
                {
                    student.StudentName = recievedstudentData.StudentName;
                    student.StudentAge = recievedstudentData.StudentAge;
                    student.StudentSubject = recievedstudentData.StudentSubject;
                    student.SubjectList = _studentRepository.Subjectlist();
                }

                _studentRepository.Insert(student);
                _studentRepository.Save();
                var updateddata = _studentRepository.GetStudents();
                return PartialView("_listOfStudents",updateddata);
            }
            else
            {
                if (recievedstudentData.StudentId != 0)
                {
                    var DataToBeUpdated = _studentRepository.findStudent(recievedstudentData.StudentId);
                    DataToBeUpdated.SubjectList = _studentRepository.Subjectlist();
                    if (DataToBeUpdated != null)
                    {
                        DataToBeUpdated.StudentId = recievedstudentData.StudentId;
                        DataToBeUpdated.StudentName = recievedstudentData.StudentName;
                        DataToBeUpdated.StudentAge = recievedstudentData.StudentAge;
                        DataToBeUpdated.StudentSubject = recievedstudentData.StudentSubject;
                        _studentRepository.Save();
                        var updatedData = _studentRepository.GetStudents();
                        return PartialView("_listOfStudents" , updatedData);
                    }
                }

                return View();
            }
        }

        [HttpGet]
        public ActionResult Remove(int? Id)
        {
            _studentRepository.Delete(Id);
            _studentRepository.Save();
            var updatedData = _studentRepository.GetStudents();
            return PartialView("_listOfStudents" , updatedData);
        }
    }
}

        
 
