﻿using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleBank.Controllers;

namespace SimpleBank.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void FooActionReturnsIndexView()
        {
            var homeControlloer = new HomeController();
            var result = homeControlloer.Foo() as ViewResult;

            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
