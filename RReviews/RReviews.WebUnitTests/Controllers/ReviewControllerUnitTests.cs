using Microsoft.VisualStudio.TestTools.UnitTesting;
using RReviews.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RReviews.Web;
using System.Web.Mvc;

namespace RReviews.Web.Controllers.UnitTests
{
    [TestClass()]
    public class ReviewControllerUnitTests
    {
        [TestMethod()]
        public void DetailsUnitTest()
        {
            RestaurantController restaurant = new RestaurantController();
            string expected = "Details";

            var action = restaurant.Details(10) as ViewResult;
            var actual = action.ViewName;

            Assert.AreEqual(expected, action);
        }

        [TestMethod()]
        public void CreateUnitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditUnitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditUnitTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteUnitTest()
        {
            Assert.Fail();
        }
    }
}