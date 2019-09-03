using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GenericRepositoryUoW.Controllers;
using GenericRepositoryUoW.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericRepositoryUoW.Tests.Controllers
{
    [TestClass]
    public class DepartmentControllerTest
    {
        [TestMethod]
        public void DetailsViewData()
        {
            var controller = new DepartmentController();
            var result = controller.Details(1) as ViewResult;
            var departmentCourse = (List<DepartmentCourse>)result.ViewData.Model;
            Assert.AreEqual(4, departmentCourse.Count);
        }

        [TestMethod]
        public void IndexViewData()
        {
            var controller = new DepartmentController();
            var result = controller.Index() as ViewResult;
            var lstdepartment = (List<Department>)result.ViewData.Model;
            Assert.AreEqual(6, lstdepartment.Count);
        }
    }
}
