using GenericRepositoryUoW.Data.Models;
using System;
using System.Linq;

namespace GenericRepositoryUoW.Services.Interfaces
{
    /// <summary>
    /// Repository interface that takes generic parameter class 
    /// </summary>
    public interface ITestService : IDisposable
    {
        /// <summary>
        /// Generic Method that returns Queryable T Type
        /// </summary>
        /// <param name="predicate">Func delegate that can be used as Lambda expression</param>
        /// <param name="includes">parameter that helps to reach deep levels of entities</param>
        /// <returns>Queryable T Type</returns>
        IQueryable<Test> GetAll(Func<Test, bool> predicate = null, params string[] includes);

        /// <summary>
        /// Generic Method that returns T Type
        /// </summary>
        /// <param name="predicate">Func delegate that can be used as Lambda expression</param>
        /// <param name="includes">parameter that  helps to reach deep levels of entities</param>
        /// <returns>T Type</returns>
        Test Get(Func<Test, bool> predicate, params string[] includes);

        /// <summary>
        /// Generic Method that inserts test
        /// </summary>
        /// <param name="test">T Type test to Insert</param>
        void Add(Test test);

        /// <summary>
        /// Generic Method that updates test
        /// </summary>
        /// <param name="test">T Type test to Update</param>
        void Attach(Test test);

        /// <summary>
        /// Generic Method that deletes test
        /// </summary>
        /// <param name="test">T Type test to Delete</param>
        void Delete(Test test);
    }
}