using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using System.Diagnostics;

namespace GenericRepositoryUoW.Data
{
    /// <summary>
    /// Implementation of GenericRepository with Context dependency
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly RepositoryContext _entities = null;
        private DbSet<T> _objectSet;

        /// <summary>
        /// Generic Repository Constructor
        /// </summary>
        /// <param name="entities"></param>
        public GenericRepository(RepositoryContext entities)
        {
            this._entities = entities;
            this._objectSet = this._entities.Set<T>();
        }

        /// <summary>
        /// GetAll Implementation with predicate delegate and include levels parameter
        /// </summary>
        /// <param name="predicate">Func delegate that can be used as Lambda expression</param>
        /// <param name="includes">parameter that helps to reach deep levels of entities</param>
        /// <returns>Queryable T Type</returns>
        public IQueryable<T> GetAll(Func<T, bool> predicate = null, params string[] includes)
        {
            //DbSet with Generic Type is our query 
            IQueryable<T> query = _objectSet;

            //to include deep level classes
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            //to constrain with predicate Func
            if (predicate != null)
            {
                return query.Where(predicate).ToArray().AsQueryable();
            }
            
            return query;
        }

        /// <summary>
        /// Get Implementation with predicate delegate and include levels parameter
        /// </summary>
        /// <param name="predicate">Func delegate that can be used as Lambda expression</param>
        /// <param name="includes">parameter that helps to reach deep levels of entities</param>
        /// <returns>T Type</returns>
        public T Get(Func<T, bool> predicate, params string[] includes)
        {
            IQueryable<T> query = _objectSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (predicate != null)
            {
                return query.First(predicate);
            }

            return query.First();
        }

        /// <summary>
        /// Add Implementation to Insert Generic T Type
        /// </summary>
        /// <param name="entity">T Type Entity to Insert</param>   
        public void Add(T entity)
        {
            _objectSet.Add(entity);
        }
        /// <summary>
        /// Edit Implementation to Insert Generic T Type
        /// </summary>
        /// <param name="entity">T Type Entity to Insert</param>   
        public void Attach(T entity)
        {
            _objectSet.AddOrUpdate(entity);
        }
        /// <summary>
        /// Edit Implementation to Insert Generic T Type
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            _objectSet.Remove(entity);
        }

    }
}