using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GenericRepositoryUoW.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Course")]
        public string Name { get; set; }

        [Display(Name = "Code")]
        public string Code { get; set; }

        public ICollection<DepartmentCourse> lstDepartmentCourse { get; set; }

        public ICollection<Test> lstTest { get; set; }
    }
}