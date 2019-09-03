using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GenericRepositoryUoW.Models
{
    public class TestType
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Name")]
        public string Name{ get; set; }

        public  ICollection<Test> lstTest { get; set; }
    }
}