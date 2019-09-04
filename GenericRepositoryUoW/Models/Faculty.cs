using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GenericRepositoryUoW.Models
{
    /// <summary>
    /// Abstraction of faculty
    /// </summary>
    public class Faculty
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Name of faculty
        /// </summary>
        [Display(Name = "Faculty")]
        public string Name{ get; set; }

        /// <summary>
        /// Departments of faculty
        /// </summary>
        public ICollection<Department> lstDepartment { get; set; }
    }
}