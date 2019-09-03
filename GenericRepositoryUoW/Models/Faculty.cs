using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GenericRepositoryUoW.Models
{
    public class Faculty
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Faculty")]
        public string Name{ get; set; }

        public ICollection<Department> lstDepartment { get; set; }
    }
}