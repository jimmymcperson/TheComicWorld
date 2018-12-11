using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheComicWorld.Models
{
    public class FakeReviewRepository : IReviewRepository
    {
        public IQueryable<Review> Reviews => new List<Review>
        {
            new Review { UserID = 10, ReviewText = "test review"},
            new Review { UserID = 11, ReviewText = "test review2"}
        }.AsQueryable<Review>();
    }
}
