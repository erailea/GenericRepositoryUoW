using System;
using System.Linq;
using GenericRepositoryUoW.Data.Models;
using GenericRepositoryUoW.Data.UoW;
using GenericRepositoryUoW.Services.Interfaces;

namespace GenericRepositoryUoW.Services
{
    /// <summary>
    /// DepartmentCourseService Service helps Repository and Controller communicate via Dependendency Injection
    /// It uses Unit of work class and its repository object and methods to interact with entities
    /// </summary>
    public class DepartmentCourseService : IDepartmentCourseService
    {
        /// <summary>
        /// encapsulated UoW instance
        /// </summary>
        private readonly IUoW _unitOfWork;

        /// <summary>
        /// Constructor needs UoW instance
        /// </summary>
        /// <param name="unitOfWork">UoW param</param>
        DepartmentCourseService(IUoW unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// DepartmentCourse insert
        /// </summary>
        /// <param name="departmentCourse">DepartmentCourse to insert</param>
        public void Add(DepartmentCourse departmentCourse)
        {
            _unitOfWork.Repository<DepartmentCourse>().Add(departmentCourse);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// DepartmentCourse update
        /// </summary>
        /// <param name="departmentCourse">DepartmentCourse to update</param>
        public void Attach(DepartmentCourse departmentCourse)
        {
            _unitOfWork.Repository<DepartmentCourse>().Attach(departmentCourse);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// DepartmentCourse delete
        /// </summary>
        /// <param name="departmentCourse">DepartmentCourse to delete</param>
        public void Delete(DepartmentCourse departmentCourse)
        {
            _unitOfWork.Repository<DepartmentCourse>().Delete(departmentCourse);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// select a DepartmentCourse object
        /// </summary>
        /// <param name="predicate">Func delegate that can be used as Lambda expression</param>
        /// <param name="includes">parameter that helps to reach deep levels of entities</param>
        /// <returns>DepartmentCourse object</returns>
        public DepartmentCourse Get(Func<DepartmentCourse, bool> predicate, params string[] includes)
        {
            return _unitOfWork.Repository<DepartmentCourse>().Get(predicate, includes);
        }

        /// <summary>
        /// select multiple DepartmentCourse objects
        /// </summary>
        /// <param name="predicate">Func delegate that can be used as Lambda expression</param>
        /// <param name="includes">parameter that helps to reach deep levels of entities</param>
        /// <returns>DepartmentCourse list</returns>
        public IQueryable<DepartmentCourse> GetAll(Func<DepartmentCourse, bool> predicate = null, params string[] includes)
        {
            return _unitOfWork.Repository<DepartmentCourse>().GetAll(predicate, includes);
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
