using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Models
{
    public class StudentDataModel
    {

        [Key]
        public int? StudentId { get; set; }

        [Required(ErrorMessage = "This field is Required")]

        public string StudentName { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        public int? StudentAge { get; set; }

        public  string StudentSubject { get; set; }

        public List<SelectListItem> SubjectList { get; set; }
    }
}