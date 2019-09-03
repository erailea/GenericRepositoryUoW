using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GenericRepositoryUoW.Models
{
    public class Test
    {
        [Key]
        public int ID { get; set; }

        public Year Year { get; set; }

        public TestType TestType { get; set; }
        public int? Course_ID { get; set; }

        [ForeignKey("Course_ID")]
        public Course Course { get; set; }

        public ICollection<Question> lstQuestion { get; set; }
    }

}