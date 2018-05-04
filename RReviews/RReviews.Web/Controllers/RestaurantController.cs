using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RReviews.BLL;
using RestaurantModels;

namespace RReviews.Web.Controllers
{
    public class RestaurantController : Controller
    {
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

        public ActionResult Search()
        {
            ViewBag.max = 0;
            return View(RestaurantAccessLibrary.GetRestaurantsByNameAscending());
        }

        // POST: Restaurant/Create
        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            try
            {
                // TODO: Add insert logic here
                RestaurantAccessLibrary.AddNewRestaurnt(restaurant);
                return RedirectToAction("search");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Restaurant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
