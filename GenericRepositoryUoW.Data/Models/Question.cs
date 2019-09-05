using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GenericRepositoryUoW.Data.Models
{
    /// <summary>
    /// Abstraction of question
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Correct choice of question
        /// </summary>
        [StringLength(1, MinimumLength = 1)]
        [Required]
        public string CorrectChoice { get; set; }

        /// <summary>
        /// Question image URL
        /// </summary>
        [Required]
        public string ImageURL { get; set; }

    }
}