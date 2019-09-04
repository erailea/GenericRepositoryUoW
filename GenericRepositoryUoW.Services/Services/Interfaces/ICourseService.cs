using GenericRepositoryUoW.Data.Models;
using System;
using System.Linq;

namespace GenericRepositoryUoW.Services.Interfaces
{
    /// <summary>
    /// Repository interface that takes generic parameter class 
    /// </summary>
    public interface ICourseService : IDisposable
    {
        /// <summary>
        /// Generic Method that returns Queryable T Type
        /// </summary>
        /// <param name="predicate">Func delegate that can be used as Lambda expression</param>
        /// <param name="includes">parameter that helps to reach deep levels of entities</param>
        /// <returns>Queryable T Type</returns>
        IQueryable<Course> GetAll(Func<Course, bool> predicate = null, params string[] includes);

        /// <summary>
        /// Generic Method that returns T Type
        /// </summary>
        /// <param name="predicate">Func delegate that can be used as Lambda expression</param>
        /// <param name="includes">parameter that  helps to reach deep levels of entities</param>
        /// <returns>T Type</returns>
        Course Get(Func<Course, bool> predicate, params string[] includes);

        /// <summary>
        /// Generic Method that inserts course
        /// </summary>
        /// <param name="course">T Type course to Insert</param>
        void Add(Course course);

        /// <summary>
        /// Generic Method that updates course
        /// </summary>
        /// <param name="course">T Type course to Update</param>
        void Attach(Course course);

        /// <summary>
        /// Generic Method that deletes course
        /// </summary>
        /// <param name="course">T Type course to Delete</param>
        void Delete(Course course);
    }
}