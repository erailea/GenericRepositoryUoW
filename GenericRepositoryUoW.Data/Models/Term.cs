using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GenericRepositoryUoW.Data.Models
{
    /// <summary>
    /// Abstraction of college term, time range
    /// </summary>
    public class Term
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Name definition of entity
        /// </summary>
        [Display(Name = "Term")]
        public string Name{ get; set; }
    }
}