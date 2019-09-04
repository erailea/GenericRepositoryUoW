using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GenericRepositoryUoW.Models
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
        public string CorrectChoice { get; set; }

        /// <summary>
        /// Question image URL
        /// </summary>
        public string ImageURL { get; set; }

    }
}