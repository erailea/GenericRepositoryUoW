using GenericRepositoryUoW.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace GenericRepositoryUoW.Data.UoW
{
    /// <summary>
    /// Implementation of IGenericUoW which helps us entity operation over the repository
    /// </summary>
    public class UoW : IUoW
    {
        private readonly RepositoryContext entities = null;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        /// <summary>
        /// UoW Constructor takes Context Parameter and return our UoW operator. 
        /// </summary>
        /// <param name="entities"></param>
        public UoW(RepositoryContext entities)
        {
            this.entities = entities;
        }

        /// <summary>
        /// When we need our repo in controllers we will call that repository function with needed entity type
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <returns></returns>
        public IRepository<T> Repository<T>() where T : class
        {
            IRepository<T> repo = new Repository<T>(this.entities);
            return repo;
        }

        /// <summary>
        /// If we need to run a specific query other than CRUD operations we will call that function with query itself and its parameters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">specific query</param>
        /// <param name="parameters">and its params</param>
        /// <returns></returns>
        public virtual IQueryable<T> GetWithRawSql<T>(string query, params object[] parameters)
        {
            return entities.Database.SqlQuery<T>(query, parameters).AsQueryable();
        }

        /// <summary>
        /// To save all changes made in the context of the database we will run SaveChanges method of UoW operator.
        /// </summary>
        public void SaveChanges()
        {
            entities.SaveChanges();
        }

        /// <summary>
        /// Dispose handlers
        /// </summary>
        #region Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    entities.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}