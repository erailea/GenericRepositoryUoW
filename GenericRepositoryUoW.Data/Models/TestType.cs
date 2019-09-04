using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GenericRepositoryUoW.Data.Models
{
    /// <summary>
    /// Abstraction of Test Types
    /// </summary>
    public class TestType
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Name of Test Type
        /// </summary>
        [Display(Name = "Name")]
        public string Name{ get; set; }

        /// <summary>
        /// Tests which has that Test Type
        /// </summary>
        public ICollection<Test> lstTest { get; set; }
    }
}