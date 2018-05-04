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

        public ActionResult Search()
        {
            return View(RestaurantAccessLibrary.GetRestaurantsByNameAscending());
        }
    }
}