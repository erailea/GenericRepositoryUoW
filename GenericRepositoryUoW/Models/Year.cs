using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GenericRepositoryUoW.Models
{
    /// <summary>
    /// Abstraction of Year
    /// </summary>
    public class Year
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Name of year
        /// </summary>
        [Display(Name = "Year")]
        public string Name{ get; set; }

        /// <summary>
        /// Tests which has that Year
        /// </summary>
        public ICollection<Test> lstTest { get; set; }
    }
}