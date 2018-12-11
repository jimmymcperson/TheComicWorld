using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheComicWorld.Models;
using TheComicWorld.Models.ViewModels;

namespace TheComicWorld.Controllers
{
    public class ReviewController : Controller
    {
        private IReviewRepository repository;

        public ReviewController(IReviewRepository repo)
        {
            repository = repo;
        }
        
        [HttpGet]
        public ViewResult Review(int productid)
        {
            return View(new Review { ProductID = productid });
        }

        [HttpPost]
        public IActionResult Review(Review review)
        {
            if (ModelState.IsValid)
            {
                repository.SaveReview(review);
                return RedirectToAction("List", "Product");
            }
            else
            {
                // there is something wrong with the data values
                return View(review);
            }
        }

        public ViewResult ReviewList(int productid) => View(new ReviewViewModel{Reviews = repository.Reviews
            .Where(r => r.ProductID == productid)
            .OrderBy(r => r.ReviewID) }
        );
    }
}
