using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GenericRepositoryUoW.Models
{
    public class DepartmentCourse
    {
        [Key]
        public int ID { get; set; }
        
        public int? Department_ID { get; set; }

        [ForeignKey("Department_ID")]
        public Department Department { get; set; }
        public Course Course { get; set; }
        public Term Term { get; set; }

    }
}