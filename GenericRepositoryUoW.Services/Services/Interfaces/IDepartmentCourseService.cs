using GenericRepositoryUoW.Data.Models;
using System;
using System.Linq;

namespace GenericRepositoryUoW.Services.Interfaces
{
    /// <summary>
    /// Repository interface that takes generic parameter class 
    /// </summary>
    public interface IDepartmentCourseService : IDisposable
    {
        /// <summary>
        /// Generic Method that returns Queryable T Type
        /// </summary>
        /// <param name="predicate">Func delegate that can be used as Lambda expression</param>
        /// <param name="includes">parameter that helps to reach deep levels of entities</param>
        /// <returns>Queryable T Type</returns>
        IQueryable<DepartmentCourse> GetAll(Func<DepartmentCourse, bool> predicate = null, params string[] includes);

        /// <summary>
        /// Generic Method that returns T Type
        /// </summary>
        /// <param name="predicate">Func delegate that can be used as Lambda expression</param>
        /// <param name="includes">parameter that  helps to reach deep levels of entities</param>
        /// <returns>T Type</returns>
        DepartmentCourse Get(Func<DepartmentCourse, bool> predicate, params string[] includes);

        /// <summary>
        /// Generic Method that inserts departmentCourse
        /// </summary>
        /// <param name="departmentCourse">T Type departmentCourse to Insert</param>
        void Add(DepartmentCourse departmentCourse);

        /// <summary>
        /// Generic Method that updates departmentCourse
        /// </summary>
        /// <param name="departmentCourse">T Type departmentCourse to Update</param>
        void Attach(DepartmentCourse departmentCourse);

        /// <summary>
        /// Generic Method that deletes departmentCourse
        /// </summary>
        /// <param name="departmentCourse">T Type departmentCourse to Delete</param>
        void Delete(DepartmentCourse departmentCourse);
    }
}