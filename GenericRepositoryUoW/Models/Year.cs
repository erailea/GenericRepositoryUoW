using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GenericRepositoryUoW.Models
{
    public class Year
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Year")]
        public string Name{ get; set; }

        public  ICollection<Test> lstTest { get; set; }
    }
}