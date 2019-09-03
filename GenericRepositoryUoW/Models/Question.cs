using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GenericRepositoryUoW.Models
{
    
    public class Question
    {
        [Key]
        public int ID { get; set; }

        [StringLength(1, MinimumLength = 1)]
        public string CorrectChoice { get; set; }

        public string ImageURL { get; set; }

    }
}