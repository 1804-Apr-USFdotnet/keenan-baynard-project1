using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RReviews.BLL;
using NLog;

namespace RReviews.Web.Controllers
{
    public class SearchController : Controller
    {
        Logger log = LogManager.GetCurrentClassLogger();
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(IEnumerable<RestaurantModels.Restaurant> restaurants, string type = " ", int max = 90)
        {

            Tuple<int, IEnumerable<RestaurantModels.Restaurant>, string> tuple;
            if (type != "")
            {
                tuple = new Tuple<int, IEnumerable<RestaurantModels.Restaurant>, string>(max, restaurants, type);
            }
            else
            {
                tuple = new Tuple<int, IEnumerable<RestaurantModels.Restaurant>, string>(0, new List<RestaurantModels.Restaurant>(), "");
                log.Error($"{tuple} has invalid values");
            }
            return View(tuple);
        }
    }
}