using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RReviews.BLL;
using RestaurantModels;

namespace RReviews.Web.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            return View();
        }

        // GET: Review/Details/5
        public ActionResult Details(int id)
        {
            return View(RestaurantAccessLibrary.GetRestaurantByID(id).Reviews);
        }

        // GET: Review/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(int id, Review review)
        {
            if (!ModelState.IsValid)
            {
                return View(review);
            }
            try
            {
                // TODO: Add insert logic here
                review.RestaurantID = id;
                RestaurantAccessLibrary.AddNewReview(review);
                return RedirectToAction("Search", "Search", null);
            }
            catch
            {
                return View();
            }
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int id)
        {
            return View(RestaurantAccessLibrary.GetReviewByID(id));
        }

        // POST: Review/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Review review)
        {
            if (!ModelState.IsValid)
            {
                return View(review);
            }
            try
            {
                // TODO: Add update logic here
                RestaurantAccessLibrary.EditReview(id, review);
                return RedirectToAction("Search", "Search", null);
            }
            catch
            {
                return View();
            }
        }

        // GET: Review/Delete/5
        public ActionResult Delete(int id)
        {
            return View(RestaurantAccessLibrary.GetReviewByID(id));
        }

        // POST: Review/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return View(id);
            }
            try
            {
                // TODO: Add delete logic here
                Review rev = RestaurantAccessLibrary.GetReviewByID(id);
                RestaurantAccessLibrary.DeleteReview(rev);
                return RedirectToAction("Search","Search");
            }
            catch
            {
                return View();
            }
        }
    }
}
