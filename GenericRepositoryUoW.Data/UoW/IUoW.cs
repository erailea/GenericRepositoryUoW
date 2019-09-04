using GenericRepositoryUoW.Data;
using GenericRepositoryUoW.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryUoW.Data.UoW
{
    /// <summary>
    /// Unit Of Work Pattern Interface
    /// </summary>
    public interface IUoW : IDisposable
    {
        /// <summary>
        /// That Method will help us to get our needed repository which we use its methods to interact with entity 
        /// </summary>
        /// <typeparam name="T">Type Param represents entity</typeparam>
        /// <returns>Our needed repository</returns>
        IRepository<T> Repository<T>() where T : class;

        /// <summary>
        /// SaveChange methods which we run after entity interactions
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Unit Of Work Dispose method
        /// </summary>
        new void Dispose();
    }
}
