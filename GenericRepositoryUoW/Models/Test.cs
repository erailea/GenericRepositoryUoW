using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GenericRepositoryUoW.Models
{
    /// <summary>
    /// Abstraction of Test
    /// </summary>
    public class Test
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Year of test
        /// </summary>
        public Year Year { get; set; }

        /// <summary>
        /// Test type of test
        /// </summary>
        public TestType TestType { get; set; }

        /// <summary>
        /// Foreign key int value to use in predicate Func get specific Test
        /// </summary>
        public int? Course_ID { get; set; }

        /// <summary>
        /// Course
        /// </summary>
        [ForeignKey("Course_ID")]
        public Course Course { get; set; }

        /// <summary>
        /// Questions of test
        /// </summary>
        public ICollection<Question> lstQuestion { get; set; }
    }

}