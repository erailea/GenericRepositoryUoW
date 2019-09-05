using System;
using System.Linq;
using GenericRepositoryUoW.Data.Models;
using GenericRepositoryUoW.Data.UoW;
using GenericRepositoryUoW.Services.Interfaces;

namespace GenericRepositoryUoW.Services
{
    /// <summary>
    /// Department Service helps Repository and Controller communicate via Dependendency Injection
    /// It uses Unit of work class and its repository object and methods to interact with entities
    /// </summary>
    public class DepartmentService : IDepartmentService
    {
        /// <summary>
        /// encapsulated UoW instance
        /// </summary>
        private readonly IUoW _unitOfWork;

        /// <summary>
        /// Constructor needs UoW instance
        /// </summary>
        /// <param name="unitOfWork">UoW param</param>
        public DepartmentService(IUoW unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Department insert
        /// </summary>
        /// <param name="department">Department to insert</param>
        public void Add(Department department)
        {
            _unitOfWork.Repository<Department>().Add(department);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Department update
        /// </summary>
        /// <param name="department">Department to update</param>
        public void Attach(Department department)
        {
            _unitOfWork.Repository<Department>().Attach(department);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Department delete
        /// </summary>
        /// <param name="department">Department to delete</param>
        public void Delete(Department department)
        {
            _unitOfWork.Repository<Department>().Delete(department);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// select a Department object
        /// </summary>
        /// <param name="predicate">Func delegate that can be used as Lambda expression</param>
        /// <param name="includes">parameter that helps to reach deep levels of entities</param>
        /// <returns>Department object</returns>
        public Department Get(Func<Department, bool> predicate, params string[] includes)
        {
            return _unitOfWork.Repository<Department>().Get(predicate, includes);
        }

        /// <summary>
        /// select multiple Department objects
        /// </summary>
        /// <param name="predicate">Func delegate that can be used as Lambda expression</param>
        /// <param name="includes">parameter that helps to reach deep levels of entities</param>
        /// <returns>Department list</returns>
        public IQueryable<Department> GetAll(Func<Department, bool> predicate = null, params string[] includes)
        {
            return _unitOfWork.Repository<Department>().GetAll(predicate, includes);
        }

        /// <summary>
        /// dispose
        /// </summary>
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
