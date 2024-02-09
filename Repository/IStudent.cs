using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using StudentManagement.Database;
using StudentManagement.Models;

namespace StudentManagement.Repository
{
     public interface IStudent 
     {
        IEnumerable<StudentDataModel> GetStudents();
        DataStudent findStudent(int? Id);
        void Insert(DataStudent recievedstudentData);
        void Update( StudentDataModel recievedstudentData);
        void Delete(int? Id);
        void Save();
        List<SelectListItem> Subjectlist();
     }
}
