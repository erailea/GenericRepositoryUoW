using System;
using System.Linq;
using GenericRepositoryUoW.Data.Models;
using GenericRepositoryUoW.Data.UoW;
using GenericRepositoryUoW.Services.Interfaces;

namespace GenericRepositoryUoW.Services
{
    /// <summary>
    /// Test Service helps Repository and Controller communicate via Dependendency Injection
    /// It uses Unit of work class and its repository object and methods to interact with entities
    /// </summary>
    public class TestService : ITestService
    {
        /// <summary>
        /// encapsulated UoW instance
        /// </summary>
        private readonly IUoW _unitOfWork;

        /// <summary>
        /// Constructor needs UoW instance
        /// </summary>
        /// <param name="unitOfWork">UoW param</param>
        TestService(IUoW unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Test insert
        /// </summary>
        /// <param name="test">Test to insert</param>
        public void Add(Test test)
        {
            _unitOfWork.Repository<Test>().Add(test);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Test update
        /// </summary>
        /// <param name="test">Test to update</param>
        public void Attach(Test test)
        {
            _unitOfWork.Repository<Test>().Attach(test);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Test delete
        /// </summary>
        /// <param name="test">Test to delete</param>
        public void Delete(Test test)
        {
            _unitOfWork.Repository<Test>().Delete(test);
            _unitOfWork.SaveChanges();
        }
        /// <summary>
        /// select a Test object
        /// </summary>
        /// <param name="predicate">Func delegate that can be used as Lambda expression</param>
        /// <param name="includes">parameter that helps to reach deep levels of entities</param>
        /// <returns>Test object</returns>
        public Test Get(Func<Test, bool> predicate, params string[] includes)
        {
            return _unitOfWork.Repository<Test>().Get(predicate, includes);
        }

        /// <summary>
        /// select multiple Test objects
        /// </summary>
        /// <param name="predicate">Func delegate that can be used as Lambda expression</param>
        /// <param name="includes">parameter that helps to reach deep levels of entities</param>
        /// <returns>Test list</returns>
        public IQueryable<Test> GetAll(Func<Test, bool> predicate = null, params string[] includes)
        {
            return _unitOfWork.Repository<Test>().GetAll(predicate, includes);
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
