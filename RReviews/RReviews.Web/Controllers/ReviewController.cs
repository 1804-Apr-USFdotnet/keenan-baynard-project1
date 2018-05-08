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
    public class ReviewController : Controller
    {
        Logger log = LogManager.GetCurrentClassLogger();
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
        public ActionResult Create(int id)
        {
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(int id, Review review)
        {
            if (!ModelState.IsValid)
            {
                log.Error($"{review} is not valid");
                return View(review);
            }
            try
            {
                review.RestaurantID = id;
                RestaurantAccessLibrary.AddNewReview(review);
                return RedirectToAction("Search", "Search", null);
            }
            catch (Exception e)
            {
                log.Error($"Exception, {e}");
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
                log.Error($"{review} is not valid");
                return View(review);
            }
            try
            {
                RestaurantAccessLibrary.EditReview(id, review);
                return RedirectToAction("Search", "Search", null);
            }
            catch (Exception e)
            {
                log.Error($"Exception, {e}");
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
                log.Error($"is not valid");
                return View(id);
            }
            try
            {
                Review rev = RestaurantAccessLibrary.GetReviewByID(id);
                RestaurantAccessLibrary.DeleteReview(rev);
                return RedirectToAction("Search", "Search");
            }
            catch (Exception e)
            {
                log.Error($"Exception, {e}");
                return View();
            }
        }
    }
}
