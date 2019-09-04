using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GenericRepositoryUoW.Data.Models
{
    /// <summary>
    /// Abstraction of college department
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Name definition of entity
        /// </summary>
        [Display(Name = "Department")]
        public string Name{ get; set; }

        /// <summary>
        /// Faculty of department
        /// </summary>
        [Display(Name = "Faculty")]
        public  Faculty Faculty { get; set; }

        /// <summary>
        /// Description of Department
        /// </summary>
        [Display(Name = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// List to hold Department - Course n to n relationship
        /// </summary>
        public ICollection<DepartmentCourse> lstDepartmentCourse { get; set; }
    }
}