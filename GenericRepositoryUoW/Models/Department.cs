using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GenericRepositoryUoW.Models
{
    public class Department
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Department")]
        public string Name{ get; set; }

        [Display(Name = "Faculty")]
        public  Faculty Faculty { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
        
        public ICollection<DepartmentCourse> lstDepartmentCourse { get; set; }
    }
}