using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using GenericRepositoryUoW.Data.Models;

namespace GenericRepositoryUoW.Data.UoW
{
    /// <summary>
    /// Repository context manages our DB connection, DB config and holds DBSets
    /// </summary>
    public partial class RepositoryContext : DbContext
    {
        /// <summary>
        /// We set our connection string which is in Web Config
        /// </summary>
        public RepositoryContext()
            : base("name=DefaultConnection") 
        {
            //Added for unit test.
            Database.SetInitializer<RepositoryContext>(null);
            this.Configuration.LazyLoadingEnabled = false;
        }

        //Set our DBSets in our context. 
        public DbSet<Question> Questions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentCourse> DepartmentCourses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Faculty> Facultys { get; set; }

        /// <summary>
        /// When our context is first created and build the model and its mappings in memory, that method will run. So we set our configuration here
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //to remove the Pluralizing convention
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}