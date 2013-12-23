using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SensibleSubstitute.Controllers;

namespace SensibleSubstitute.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        private HomeController controller;

        [TestInitialize]
        public void SetupController()
        {
            controller = new HomeController();
        }

        [TestMethod]
        public void TestIndexView()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void TestAboutView()
        {
            var controller = new HomeController();
            var result = controller.About() as ViewResult;
            Assert.AreEqual("About", result.ViewName);
        }

    }
}