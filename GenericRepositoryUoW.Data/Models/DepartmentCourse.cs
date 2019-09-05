using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GenericRepositoryUoW.Data.Models
{
    /// <summary>
    /// To reach department to course and viceversa, also maintain Department - Course n to n relationship
    /// </summary>
    public class DepartmentCourse
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Foreign key int value to use in predicate Func get specific DepartmentCourse
        /// </summary>
        public int? Department_ID { get; set; }

        /// <summary>
        /// Department 
        /// </summary>
        [ForeignKey("Department_ID")]
        public Department Department { get; set; }

        /// <summary>
        /// Course 
        /// </summary>
        [Required]
        public Course Course { get; set; }

        /// <summary>
        /// Term of Department and Course
        /// </summary>
        [Required]
        public Term Term { get; set; }

    }
}