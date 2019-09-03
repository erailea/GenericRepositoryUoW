using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace GenericRepositoryUoW.Data
{
    /// <summary>
    /// Repository interface that takes generic parameter class 
    /// </summary>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Generic Method that returns Queryable T Type
        /// </summary>
        /// <param name="predicate">Func delegate that can be used as Lambda expression</param>
        /// <param name="includes">parameter that helps to reach deep levels of entities</param>
        /// <returns>Queryable T Type</returns>
        IQueryable<T> GetAll(Func<T, bool> predicate = null, params string[] includes);

        /// <summary>
        /// Generic Method that returns T Type
        /// </summary>
        /// <param name="predicate">Func delegate that can be used as Lambda expression</param>
        /// <param name="includes">parameter that  helps to reach deep levels of entities</param>
        /// <returns>T Type</returns>
        T Get(Func<T, bool> predicate, params string[] includes);

        /// <summary>
        /// Generic Method that inserts Entity
        /// </summary>
        /// <param name="entity">T Type Entity to Insert</param>
        void Add(T entity);

        /// <summary>
        /// Generic Method that updates Entity
        /// </summary>
        /// <param name="entity">T Type Entity to Update</param>
        void Attach(T entity);

        /// <summary>
        /// Generic Method that deletes Entity
        /// </summary>
        /// <param name="entity">T Type Entity to Delete</param>
        void Delete(T entity);
    }
}
