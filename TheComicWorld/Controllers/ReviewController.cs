using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheComicWorld.Models;

namespace TheComicWorld.Controllers
{
    public class ReviewController : Controller
    {
        private IReviewRepository repository;
        public ReviewController(IReviewRepository repo)
        {
            repository = repo;
        }

        public ViewResult ReviewList() => View(repository.Reviews);
    }
}
