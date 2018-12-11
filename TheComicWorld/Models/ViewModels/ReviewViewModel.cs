using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheComicWorld.Models;

namespace TheComicWorld.Models.ViewModels
{
    public class ReviewViewModel
    {
        public IEnumerable<Review> Reviews { get; set; }
    }
}
