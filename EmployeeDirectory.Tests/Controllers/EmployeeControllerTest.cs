using EmployeeDirectory.Data;
using EmployeeDirectory.Data.Entities;
using EmployeeDirectory.Data.Service;
using EmployeeDirectory.Web;
using EmployeeDirectory.Web.Controllers;
using EmployeeDirectory.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace EmployeeDirectory.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        [TestMethod]
        public void AutocompleteSearch()
        {
            // Arrange
            EmployeesController controller = new EmployeesController(new MockDirectoryService());

            // Act
            ViewResult result = controller.Index(1) as ViewResult;
            JsonResult jr = controller.AutocompleteSearch("Abb");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}