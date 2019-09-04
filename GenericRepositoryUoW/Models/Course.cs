using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GenericRepositoryUoW.Models
{
    /// <summary>
    /// Abstraction of College Courses
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Name definiton of entity
        /// </summary>
        [Display(Name = "Course")]
        public string Name { get; set; }

        /// <summary>
        /// Courses code
        /// </summary>
        [Display(Name = "Code")]
        public string Code { get; set; }

        /// <summary>
        /// List to hold Department - Course n to n relationship
        /// </summary>
        public ICollection<DepartmentCourse> lstDepartmentCourse { get; set; }

        /// <summary>
        /// Test entities that on this very course
        /// </summary>
        public ICollection<Test> lstTest { get; set; }
    }
}