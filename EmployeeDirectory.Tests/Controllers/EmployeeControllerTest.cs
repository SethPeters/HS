using EmployeeDirectory.Web;
using EmployeeDirectory.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace EmployeeDirectory.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            EmployeesController controller = new EmployeesController();

            // Act
            ViewResult result = controller.Index(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}