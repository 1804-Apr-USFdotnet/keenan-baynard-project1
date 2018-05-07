using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RReviews.BLL;
using RestaurantModels;
using NLog;

namespace RReviews.Web.Controllers
{
    public class RestaurantController : Controller
    {
        Logger log = LogManager.GetCurrentClassLogger();
        // GET: Restaurant
        public ActionResult Index()
        {
            return View(RestaurantAccessLibrary.GetRestaurantsByNameAscending());
        }

        // GET: Restaurant/Details/5
        public ActionResult Details(int id)
        {
            return View(RestaurantAccessLibrary.GetRestaurantByID(id));
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                log.Error($"{restaurant} is not a valid model");
                return View(restaurant);
            }
            try
            {
                // TODO: Add insert logic here
                RestaurantAccessLibrary.AddNewRestaurnt(restaurant);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                log.Error($"Exception, {e}");
                return View();
            }
        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            return View(RestaurantAccessLibrary.GetRestaurantByID(id));
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                log.Error($"{restaurant} is not a valid model");
                return View(restaurant);
            }
            try
            {
                // TODO: Add update logic here
                RestaurantAccessLibrary.EditRestaurant(id, restaurant);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                log.Error($"Exception, {e}");
                return View();
            }
        }

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int id)
        {
            return View(RestaurantAccessLibrary.GetRestaurantByID(id));
        }

        // POST: Restaurant/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!ModelState.IsValid)
            {
                log.Error($"{RestaurantAccessLibrary.GetRestaurantByID(id)} is not a valid model");
                return View(id);
            }
            try
            {
                // TODO: Add delete logic here
                Restaurant rest = RestaurantAccessLibrary.GetRestaurantByID(id);
                RestaurantAccessLibrary.DeleteRestaurant(rest);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                log.Error($"Exception, {e}");
                return View();
            }
        }
    }
}
