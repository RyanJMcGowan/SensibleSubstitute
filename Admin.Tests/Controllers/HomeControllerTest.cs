using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Admin;
using Admin.Controllers;

namespace Admin.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            AdminController controller = new AdminController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            AdminController controller = new AdminController();

            // Act
            ViewResult result = controller.AddBlog() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            AdminController controller = new AdminController();

            // Act
            ViewResult result = controller.Manage() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
