using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GenericRepositoryUoW.Models
{
    public class Term
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Term")]
        public string Name{ get; set; }
    }
}