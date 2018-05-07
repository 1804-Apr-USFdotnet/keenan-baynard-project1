using Microsoft.VisualStudio.TestTools.UnitTesting;
using RReviews.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using RestaurantModels;

namespace RReviews.Web.Controllers.UnitTests
{
    [TestClass()]
    public class ReviewControllerUnitTests
    {
        [TestMethod()]
        public void DetailsModelUnitTest()
        {
            ReviewController controller = new ReviewController();

            var indexData = controller.Details(10) as ViewResult;
            var actual = indexData.Model;

            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void DetailsModelDataUnitTest()
        {
            ReviewController controller = new ReviewController();

            var result = controller.Details(100) as ViewResult;
            var data = result.Model as List<Review>;

            Assert.AreEqual("Darcy Vang", data[0].ReviewerName);
        }

        [TestMethod()]
        public void EditModelUnitTest()
        {
            ReviewController controller = new ReviewController();

            var editData = controller.Edit(10) as ViewResult;
            var actual = editData.Model;

            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void EditModelDataUnitTest()
        {
            ReviewController controller = new ReviewController();

            var result = controller.Edit(10) as ViewResult;
            var data = result.Model as Review;

            Assert.AreEqual("Cristina Reynolds", data.ReviewerName);
        }

        [TestMethod()]
        public void DeleteModelUnitTest()
        {
            ReviewController controller = new ReviewController();

            var deleteData = controller.Delete(10) as ViewResult;
            var actual = deleteData.Model;

            Assert.IsNotNull(actual);
        }
    }
}