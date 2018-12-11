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
        public IActionResult Review(int productid)
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Review(Review review)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        repository.SaveProduct(product);
        //        TempData["message"] = $"{product.Name} has been saved";
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        // there is something wrong with the data values
        //        return View(product);
        //    }
        //}

        public ViewResult ReviewList(int productid) => View(new ReviewViewModel{Reviews = repository.Reviews
            .Where(r => r.ProductID == productid)
            .OrderBy(r => r.ReviewID) }
        );
    }
}
