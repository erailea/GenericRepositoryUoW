using GenericRepositoryUoW.Data.Models;
using System;
using System.Linq;

namespace GenericRepositoryUoW.Services.Interfaces
{
    /// <summary>
    /// Repository interface that takes generic parameter class 
    /// </summary>
    public interface IDepartmentService : IDisposable
    {
        /// <summary>
        /// Generic Method that returns Queryable T Type
        /// </summary>
        /// <param name="predicate">Func delegate that can be used as Lambda expression</param>
        /// <param name="includes">parameter that helps to reach deep levels of entities</param>
        /// <returns>Queryable T Type</returns>
        IQueryable<Department> GetAll(Func<Department, bool> predicate = null, params string[] includes);

        /// <summary>
        /// Generic Method that returns T Type
        /// </summary>
        /// <param name="predicate">Func delegate that can be used as Lambda expression</param>
        /// <param name="includes">parameter that  helps to reach deep levels of entities</param>
        /// <returns>T Type</returns>
        Department Get(Func<Department, bool> predicate, params string[] includes);

        /// <summary>
        /// Generic Method that inserts department
        /// </summary>
        /// <param name="department">T Type department to Insert</param>
        void Add(Department department);

        /// <summary>
        /// Generic Method that updates department
        /// </summary>
        /// <param name="department">T Type department to Update</param>
        void Attach(Department department);

        /// <summary>
        /// Generic Method that deletes department
        /// </summary>
        /// <param name="department">T Type department to Delete</param>
        void Delete(Department department);
    }
}