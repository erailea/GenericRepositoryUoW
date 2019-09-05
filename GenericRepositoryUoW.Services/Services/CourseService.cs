using System;
using System.Linq;
using GenericRepositoryUoW.Data.Models;
using GenericRepositoryUoW.Data.UoW;
using GenericRepositoryUoW.Services.Interfaces;

namespace GenericRepositoryUoW.Services
{
    /// <summary>
    /// Course Service helps Repository and Controller communicate via Dependendency Injection
    /// It uses Unit of work class and its repository object and methods to interact with entities
    /// </summary>
    public class CourseService : ICourseService
    {
        /// <summary>
        /// encapsulated UoW instance
        /// </summary>
        private readonly IUoW _unitOfWork;

        /// <summary>
        /// Constructor needs UoW instance
        /// </summary>
        /// <param name="unitOfWork">UoW param</param>
        public CourseService(IUoW unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Course insert
        /// </summary>
        /// <param name="course">Course to insert</param>
        public void Add(Course course)
        {
            _unitOfWork.Repository<Course>().Add(course);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Course update
        /// </summary>
        /// <param name="course">Course to update</param>
        public void Attach(Course course)
        {
            _unitOfWork.Repository<Course>().Attach(course);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Course delete
        /// </summary>
        /// <param name="course">Course to delete</param>
        public void Delete(Course course)
        {
            _unitOfWork.Repository<Course>().Delete(course);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// select a Course object
        /// </summary>
        /// <param name="predicate">Func delegate that can be used as Lambda expression</param>
        /// <param name="includes">parameter that helps to reach deep levels of entities</param>
        /// <returns>Course object</returns>
        public Course Get(Func<Course, bool> predicate, params string[] includes)
        {
            return _unitOfWork.Repository<Course>().Get(predicate, includes);
        }

        /// <summary>
        /// select multiple Course objects
        /// </summary>
        /// <param name="predicate">Func delegate that can be used as Lambda expression</param>
        /// <param name="includes">parameter that helps to reach deep levels of entities</param>
        /// <returns>Course list</returns>
        public IQueryable<Course> GetAll(Func<Course, bool> predicate = null, params string[] includes)
        {
            return _unitOfWork.Repository<Course>().GetAll(predicate, includes);
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
