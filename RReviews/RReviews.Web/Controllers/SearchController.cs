using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RReviews.BLL;

namespace RReviews.Web.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(int max = 90, string type = " ")
        {
            
            Tuple<int, IEnumerable<RestaurantModels.Restaurant>, string> tuple;
            if (type != "")
            {
                tuple = new Tuple<int, IEnumerable<RestaurantModels.Restaurant>, string>(max, RestaurantAccessLibrary.GetRestaurantsByNameAscending(), type);
            }
            else
            {
                tuple = new Tuple<int, IEnumerable<RestaurantModels.Restaurant>, string>(0,new List<RestaurantModels.Restaurant>(), "");
            }
            return View(tuple);
        }
    }
}