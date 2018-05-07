using Microsoft.VisualStudio.TestTools.UnitTesting;
using RReviews.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RReviews.Web;
using System.Web.Mvc;
using RestaurantModels;

namespace RReviews.Web.Controllers.UnitTests
{
    [TestClass()]
    public class RestaurantControllerUnitTests
    {
        [TestMethod()]
        public void DetailsModelUnitTest()
        {
            RestaurantController controller = new RestaurantController();
           
            var detailsData = controller.Details(10) as ViewResult;
            var actual = detailsData.Model;
           
            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void DetailsModelDataUnitTest()
        {
            RestaurantController controller = new RestaurantController();
            
            var result = controller.Details(50) as ViewResult;
            var data = result.Model as Restaurant;
            
            Assert.AreEqual("Marshall Islands", data.State);
        }

        [TestMethod()]
        public void EditModelUnitTest()
        {
            RestaurantController controller = new RestaurantController();

            var editData = controller.Edit(10) as ViewResult;
            var actual = editData.Model;

            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void EditModelDataUnitTest()
        {
            RestaurantController controller = new RestaurantController();

            var result = controller.Edit(50) as ViewResult;
            var data = result.Model as Restaurant;

            Assert.AreEqual("Marshall Islands", data.State);
        }

        [TestMethod()]
        public void DeleteModelUnitTest()
        {
            RestaurantController controller = new RestaurantController();

            var deleteData = controller.Delete(10) as ViewResult;
            var actual = deleteData.Model as Restaurant;

            Assert.IsNotNull(actual);
        }
    }
}